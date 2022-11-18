using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microvast.Common.Vuex;
using Microvast.Model;
using Microvast.Service;
using Microvast.ViewModel;
using Microvast.Common.Utils;
using Sunny.UI;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
using System.Data;
using System.IO;

using System.Globalization;

using System.Runtime.InteropServices;



using System.Configuration;
//*****************


// ScreenDemo1;
namespace ScreenDemo1
{
    public class S7HelperNew
    {
        SiemensS7Net PLC;
        public string PLCIP = string.Empty;
        public int PLCPort = 0;
        public List<DataValue> Datavalue = new List<DataValue>();
        public static Dictionary<int, OpcConnect> opcItems = new Dictionary<int, OpcConnect>();
        Thread thread;
        public bool PLCCon(string IP)
        {
            for (var i = 0; i < Form1.mainForm.dataRefenceList.Count; i++)
            {
                OpcConnect opcConnect = new OpcConnect();//建立OPC连接
                opcConnect.clientHandle = i;
                opcConnect.itemId = Form1.mainForm.dataRefenceList[i].sign_name;//将itemid设置成表中的DB地址
                opcConnect.requestedDataType = short.Parse(Convert.ToString(Form1.mainForm.dataRefenceList[i].requested_datatype));
                opcConnect.signType = Convert.ToInt32(Form1.mainForm.dataRefenceList[i].sign_type);
                opcConnect.noCheckType = Convert.ToInt32(Form1.mainForm.dataRefenceList[i].no_checktype);
                opcItems.Add(i, opcConnect);//插入一个OPC连接
                DataValue datavalue = new DataValue();
                datavalue.p_trig = new P_TRIG();
                datavalue.signtype = Convert.ToInt32(Form1.mainForm.dataRefenceList[i].sign_type);
                datavalue.datatype = short.Parse(Convert.ToString(Form1.mainForm.dataRefenceList[i].requested_datatype));
                datavalue.value = "";
                Datavalue.Add(datavalue);
            }
            if(Datavalue.Count>0)
            {
                if(Form1.mainForm.PLC类型=="1500")
                {
                    PLC = new SiemensS7Net(SiemensPLCS.S1500, IP);
                }
                else if(Form1.mainForm.PLC类型 == "1200")
                {
                    PLC = new SiemensS7Net(SiemensPLCS.S1200, IP);
                }
                OperateResult con = PLC.ConnectServer();
                if (con.IsSuccess)
                {
                    thread = new Thread(new ThreadStart(DataUpdata));
                    thread.IsBackground = true;
                    thread.Start();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;

            }

        }



        void DataUpdata()
        {
            while (true)
            {
                try
                {
                    for (int a = 0; a < opcItems.Count; a++)
                    {
                        if (opcItems[a].requestedDataType == 11)
                        {
                            bool result = PLC.ReadBool(opcItems[a].itemId).Content;
                            Datavalue[a].p_trig.CLK = result.ToString();
                            Datavalue[a].value = result.ToString();
                            if (result && Datavalue[a].p_trig.Q)
                            {
                                for (int i = 0; i < opcItems.Count; i++)
                                {
                                    if (opcItems[i].requestedDataType == 5)
                                    {
                                        // PLC.re
                                        float result1 = PLC.ReadFloat(opcItems[i].itemId).Content;
                                        Datavalue[i].p_trig.CLK = result1.ToString();
                                        Datavalue[i].value = result1.ToString();
                                    }
                                    if (opcItems[i].requestedDataType == 3)
                                    {
                                        short result2 = PLC.ReadInt16(opcItems[i].itemId).Content;
                                        Datavalue[i].p_trig.CLK = result2.ToString();
                                        Datavalue[i].value = result2.ToString();
                                    }
                                    if (opcItems[i].requestedDataType == 8)
                                    {
                                        string result3 = PLC.ReadString(opcItems[i].itemId).Content;
                                        Datavalue[i].p_trig.CLK = result3.ToString();
                                        Datavalue[i].value = result3.ToString();
                                    }
                                    if (opcItems[a].requestedDataType == 8196)
                                    {
                                        string[] adress = opcItems[a].itemId.Split('L');
                                        if (adress.Length == 2)
                                        {
                                            // float result1 = PLC.ReadFloat(adress[0]).Content;
                                            OperateResult<float[]> value1 = PLC.ReadFloat(adress[0], ushort.Parse(adress[1]));
                                            string str = string.Empty;
                                            for (int j = 0; j < value1.Content.Length; j++)
                                            {
                                                //数值只保留小数点后三位
                                                string val = decimal.Round(decimal.Parse(value1.Content[j].ToString(), System.Globalization.NumberStyles.Float), 3).ToString("f3");
                                                str += string.Format("{0},", val);//将数值加到字符串的最后
                                            }
                                            Datavalue[a].value = str != string.Empty ? str.Substring(0, str.Length - 1) : str;
                                        }
                                    }
                                }
                                ToSingTypeName(opcItems[a].signType);
                                HandleReadSignType(opcItems[a].signType);
                            }
                        }
                        if (opcItems[a].requestedDataType == 5)
                        {
                            float result = PLC.ReadFloat(opcItems[a].itemId).Content;
                            Datavalue[a].p_trig.CLK = result.ToString();
                            Datavalue[a].value = result.ToString();
                        }
                        if (opcItems[a].requestedDataType == 3)
                        {
                            short result = PLC.ReadInt16(opcItems[a].itemId).Content;
                            Datavalue[a].p_trig.CLK = result.ToString();
                            Datavalue[a].value = result.ToString();
                            if (Datavalue[a].p_trig.Q)
                            {
                                ToSingTypeName(opcItems[a].signType);
                                HandleReadSignType(opcItems[a].signType);
                            }
                        }
                        if (opcItems[a].requestedDataType == 8196)
                        {
                            string[] adress = opcItems[a].itemId.Split('L');
                            if (adress.Length == 2)
                            {
                                float result1 = PLC.ReadFloat(adress[0]).Content;
                                OperateResult<float[]> value1 = PLC.ReadFloat(adress[0], ushort.Parse(adress[1]));
                                string str = string.Empty;
                                for (int i = 0; i < value1.Content.Length; i++)
                                {
                                    //数值只保留小数点后三位
                                    string val = decimal.Round(decimal.Parse(value1.Content[i].ToString(), System.Globalization.NumberStyles.Float), 3).ToString("f3");
                                    str += string.Format("{0},", val);//将数值加到字符串的最后
                                }
                                Datavalue[a].value = str != string.Empty ? str.Substring(0, str.Length - 1) : str;
                            }
                        }
                        if (opcItems[a].requestedDataType == 8)
                        {
                            string result = PLC.ReadString(opcItems[a].itemId).Content;
                            Datavalue[a].p_trig.CLK = result.ToString();
                            Datavalue[a].value = result.ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    string info = string.Format(ex.Message);
                   // addLogs(info, 2);
                    //log.Info(info);
                }
                Thread.Sleep(600);
            }
        }


        public string ToSingTypeName(int singType)
        {
            string singTypeName = "";
            switch (singType)
            {
                case 1:
                    singTypeName = "进入数据查询信号";
                    break;
                case 2:
                    singTypeName = "离开数据传输信号1";
                    break;
                case 3:
                    singTypeName = "NG数据传输信号";
                    break;
                case 4:
                    singTypeName = "激光打印信号";
                    break;
                case 5:
                    singTypeName = "返工模式信号";
                    break;
                case 7:
                    singTypeName = "离开数据传输信号2";
                    break;
                case 90:
                    singTypeName = "产品绑定条码开始";
                    break;
                case 96:
                case 97:
                    singTypeName = "抽检数据上传信号";
                    break;
                case 98:
                    singTypeName = "切换设备状态信号";
                    break;
                case 99:
                    singTypeName = "打印机信号";
                    break;
                case 10:
                    singTypeName = "读取电机1";
                    break;
                case 0:
                    break;
                case 95:
                    singTypeName = "离站数据查询！";
                    break;
                default:
                    if (singType >= 10 && singType <= 20)
                        singTypeName = "点检数据上传信号";
                    else if (singType > 20 && singType <= 30)
                        singTypeName = "抽检数据上传信号";
                    else
                        singTypeName = "signType:" + singType.ToString() + ":第三方设备信号";
                    break;
            }
            return singTypeName;
        }
        public void HandleReadSignType(int signType)
        {
            string str = string.Empty;
            foreach (DataValue item in Datavalue)
            {
                str += item == null ? string.Empty + "," : item.value + ",";
            }
           // log.Info("opc接收到的值数组:" + str.Substring(0, str.Length - 1));
            // 接收PLC请求的交互标志型号
            // 不在0 - 100 的范围， 不在则不处理 
            if (signType > 100 || signType < 0) return;
            // 日志记录PLC发送到OPC中的数据
            string datamsg = "";
            for (int a = 0; a < Datavalue.Count; a++)
            {
                datamsg = datamsg + Datavalue[a].value + ",";
            }
           // Info(signType, datamsg.Substring(0, datamsg.Length - 1));
            // 获取对应信号（0 - 100）的数据，处理数据
            // 1进入数据查询信号(检测上一站信息)  
            // 2离开数据传输信号   
            // 3NG数据传输  
            // 4激光打印信号  
            // 5返工模式   
            // 7右侧工位离开数据上传
            // 9右侧工位前道工序查询
            // 96抽检数据上传信号
            // 97抽检数据上传信号
            // 98设备状态切换
            // 99打印模式  
            // 6以后第三方
            // 8PLC报警信息
            var returnList = GetResultRead(signType);
            switch (signType)
            {
                case 1:
               
                    break;
                default:
                    if (signType >= 60 && signType < 90)
                    {
                       // new ProcessCurve().UploadThirdEquipmentPath(returnList, signType);
                    }
                    break;
                
            }
        }


        public Dictionary<string, OpcConnect> GetResultRead(int signType)
        {
            Dictionary<string, OpcConnect> readList = new Dictionary<string, OpcConnect>();
            try
            {
                //筛选数据，刷选的signType是信号的值加上100
                int checkSignType = signType + 100;
                for (var i = 0; i < Datavalue.Count; i++)//遍历序号数组
                {
                    var num = i;//获取序号
                    //当前值为浮点数组时
                    if (Datavalue[i].datatype == 8196)
                    {
                        string str = string.Empty;
                        foreach (var item in Datavalue[i].value)//遍历浮点数组中的每一个数值
                        {
                            //数值只保留小数点后三位
                            string val = decimal.Round(decimal.Parse(item.ToString(), System.Globalization.NumberStyles.Float), 3).ToString("f3");
                            str += string.Format("{0},", val);//将数值加到字符串的最后
                        }
                        //OPC通讯项接收到的消息不为空，则处理数据，否则即为空
                        opcItems[num].receiveMsg = str != string.Empty ? str.Substring(0, str.Length - 1) : str;
                    }
                    else//当数据不为浮点数组时，直接将通讯项消息赋值为当前结果值
                    {
                       opcItems[num].receiveMsg = Convert.ToString(Datavalue[i].value);
                    }
                    //当OPC信号类型=当前信息类型，或者两者都为98时
                    if (opcItems[num].signType == checkSignType ||
                        (opcItems[num].signType == 98 && signType == 98) ||
                        (opcItems[num].signType == 8 && signType == 8))
                    {
                        OpcConnect opcConnect = opcItems[num];
                        readList.Add(opcConnect.itemId, opcConnect);//将数据添加到结果值中
                    }
                }
                return readList;
            }
            catch (System.Exception ex)
            {
                //log.Error(ex.Message, ex);
                return readList;
            }
        }






















        public static string ReadNode(string DataTag)
        {
            string returnData = "";
            try
            {
                S7Helper s7Helper = S7Helper.CreateInstance();
                if (DataTag.Contains("WSTRING"))
                {
                    //取到DB块号
                    int dbInt = dbInt = int.Parse(MidStrEx(DataTag, "DB", "."));
                    //取到偏移量地址
                    int strAdr = int.Parse(MidStrEx(DataTag, "WSTRING", "."));
                    byte S7StringCount = (byte)s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr + 2, VarType.Int, 1);
                    object finalStr = s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.S7String, S7StringCount);
                    returnData = finalStr.ToString();
                }
                else if (DataTag.Contains(".STRING"))
                {
                    #region 旧读String

                    #endregion
                    //取到DB块号
                    int dbInt = dbInt = int.Parse(MidStrEx(DataTag, "DB", "."));
                    //取到偏移量地址
                    int strAdr = int.Parse(MidStrEx(DataTag, "STRING", "."));
                    byte S7StringCount = (byte)s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr + 1, VarType.Byte, 1);
                    object finalStr = s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.S7String, S7StringCount);
                    returnData = finalStr.ToString();
                }
                else if (DataTag.Contains("DATETIME"))
                {
                    //取到DB块号
                    int dbInt = dbInt = int.Parse(MidStrEx(DataTag, "DB", "."));
                    var spit = DataTag.Split('.');
                    int strAdr = Convert.ToInt32(DataTag.Replace($"DB{dbInt}.DATETIME", ""));

                    //读取时在地址前加两位偏移
                    var hehe = s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.DateTime, 1);
                    returnData = hehe.ToString();
                }
                else if (DataTag.Contains("DBW"))
                {
                    //读取整数型数据
                    ushort UpValue = (ushort)s7Helper.plc.Read(DataTag);
                    returnData = Convert.ToString(UpValue);
                }
                else if (DataTag.Contains(".B"))
                {
                    //取到DB块号
                    int dbInt = dbInt = int.Parse(MidStrEx(DataTag, "DB", "."));
                    //取到偏移量地址
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    //获取字符串长度
                    var reservedLength = (byte)s7Helper.plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.Byte, 1);
                    //将读取数据转为字符串
                    returnData = Convert.ToString(reservedLength);
                }
                else if (DataTag.Contains("DBD"))
                {
                    //读取小数型数据
                    double UpValue = ((uint)s7Helper.plc.Read(DataTag)).ConvertToFloat();
                    if (Convert.ToString(UpValue).Trim() != "")
                    {
                        //截取保留小数位长度
                        returnData = Math.Round(UpValue, 3).ToString();
                    }
                }
                else if (DataTag.Contains("DBX"))
                {
                    //读取Bool值数据
                    var db1Bool1 = s7Helper.plc.Read(DataTag);
                    returnData = db1Bool1.ToString();
                }
            }
            catch (Exception ex)
            {
                //读取异常
                //S7Helper._S7Helper = null;
                return "plc断电了";
            }

            return returnData;
        }

        public static bool WriteNode(string DataTag, object value)
        {
            try
            {
                //取到DB块号
                int dbInt = dbInt = int.Parse(MidStrEx(DataTag, "DB", "."));
                //取到偏移量地址
                int strAdr = int.Parse(MidStrEx(DataTag, "STRING", "."));
                S7Helper s7Helper = S7Helper.CreateInstance();
                if (DataTag.Contains("STRING"))
                {
                    s7Helper.plc.Write(DataType.DataBlock, dbInt, strAdr, GetPLCStringByteArray(value.ToString()));
                }
                return true;
            }
            catch (Exception)
            {
                //写入异常
                //S7Helper._S7Helper = null;
                return false;
            }
        }
        /// <summary>
        /// 获取西门子PLC字符串数组--String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetPLCStringByteArray(string str)
        {
            byte[] value = Encoding.Default.GetBytes(str);
            byte[] head = new byte[2];
            head[0] = Convert.ToByte(254);
            head[1] = Convert.ToByte(str.Length);
            value = head.Concat(value).ToArray();
            return value;
        }

        /// <summary>
        /// 获取西门子PLC字符串数组--WString
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetPLCWStringByteArray(string str)
        {
            byte[] value = Encoding.BigEndianUnicode.GetBytes(str);
            byte[] head = BitConverter.GetBytes((short)508);
            byte[] length = BitConverter.GetBytes((short)str.Length);
            Array.Reverse(head);
            Array.Reverse(length);
            head = head.Concat(length).ToArray();
            value = head.Concat(value).ToArray();
            return value;
        }

        /// <summary>
        /// 去指定字符串中间字符
        /// </summary>
        /// <param name="sourse">字符串</param>
        /// <param name="startstr">首字符</param>
        /// <param name="endstr">尾字符</param>
        /// <returns></returns>
        public static string MidStrEx(string sourse, string startstr, string endstr)
        {
            string result = string.Empty;
            int startindex, endindex;
            try
            {
                startindex = sourse.IndexOf(startstr);
                if (startindex == -1)
                {
                    return result;
                }
                string tmpstr = sourse.Substring(startindex + startstr.Length);
                endindex = tmpstr.IndexOf(endstr);
                if (endindex == -1)
                {
                    return result;
                }
                result = tmpstr.Remove(endindex);

            }
            catch (Exception)
            {

            }
            return result;
        }



      



    }
    public class DataValue
    {
        public string value { set; get; }
        public int datatype { set; get; }
        public int signtype { set; get; }
        public P_TRIG p_trig { set; get; }
    }
    public class OpcConnect
    {
        /// <summary>
        /// OPC中的itemId(sign_name)
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int clientHandle { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public short requestedDataType { get; set; }
        /// <summary>
        /// 信号类型
        /// </summary>
        public int signType { get; set; }
        /// <summary>
        /// 接收到的信息
        /// </summary>
        public string receiveMsg { get; set; }
        /// <summary>
        /// 非检测项标识
        /// </summary>
        public int noCheckType { get; set; }
    }
}
