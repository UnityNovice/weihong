using System;
using System.Collections.Generic;
using SqlSugar;		
namespace Microvast.Model
{
	public class huzhou_DataRefence
	{
		public huzhou_DataRefence()
		{
		}
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        ///<summary>
        ///
        ///</summary>
        public int id { get; set; }
		
		///<summary>
		///符号名
		///</summary>
		public string sign_name { get; set; }
		
		///<summary>
		///工序号
		///</summary>
		public string process_no { get; set; }
		
		///<summary>
		///检测数据号
		///</summary>
		public string data_no { get; set; }
		
		///<summary>
		///检测数据名称
		///</summary>
		public string data_name { get; set; }
		
		///<summary>
		///检测数据类型（1：OK/NG类型；2：数值类型；3：字符类型）
		///</summary>
		public int? data_type { get; set; }
		
		///<summary>
		///备注
		///</summary>
		public string data_desc { get; set; }
		
		///<summary>
		///
		///</summary>
		public string data_unit { get; set; }
		
		///<summary>
		///
		///</summary>
		public int? data_collect { get; set; }
		
		///<summary>
		///
		///</summary>
		public int? requested_datatype { get; set; }
		
		///<summary>
		///
		///</summary>
		public int? sign_type { get; set; }
		
		///<summary>
		///
		///</summary>
		public int? no_checktype { get; set; }
		
	}
}
