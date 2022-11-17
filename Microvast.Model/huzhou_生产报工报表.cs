using SqlSugar;
using System;
using System.Collections.Generic;
using System.Security.Principal;
namespace Microvast.Model
{
	public class huzhou_生产报工报表
	{
		public huzhou_生产报工报表()
		{
		}
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        ///<summary>
        ///
        ///</summary>
        public int? Id { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? 日期 { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 工号 { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 角色 { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 名称 { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 详情 { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 工序 { get; set; }
		
	}
}
