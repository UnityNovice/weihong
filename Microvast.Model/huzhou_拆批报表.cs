using System;
using System.Collections.Generic;
using SqlSugar;

namespace Microvast.Model
{
	public class huzhou_拆批报表
	{
		public huzhou_拆批报表()
		{
		}
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        ///<summary>
        ///
        ///</summary>
        public int ID { get; set; }
		
		///<summary>
		///拆批时间
		///</summary>
		public DateTime 时间 { get; set; }
		
		///<summary>
		///拆批源批次
		///</summary>
		public string 拆批源批次 { get; set; }
		
		///<summary>
		///拆批后批次1
		///</summary>
		public string 拆批后批次1 { get; set; }
		
		///<summary>
		///拆批后批次1重量
		///</summary>
		public string 拆批后批次1重量 { get; set; }
		
		///<summary>
		///拆批后批次2
		///</summary>
		public string 拆批后批次2 { get; set; }
		
		///<summary>
		///拆批后批次2重量
		///</summary>
		public string 拆批后批次2重量 { get; set; }
		
		///<summary>
		///拆批操作者
		///</summary>
		public string 拆批操作者 { get; set; }
		
	}
}
