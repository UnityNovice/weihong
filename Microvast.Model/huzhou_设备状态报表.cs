using System;
using System.Collections.Generic;
		
namespace Microvast.Model
{
	public class huzhou_设备状态报表
	{
		public huzhou_设备状态报表()
		{
		}
		
		///<summary>
		///
		///</summary>
		public int Id { get; set; }
		
		///<summary>
		///
		///</summary>
		public string 工序 { get; set; }
		
		///<summary>
		///
		///</summary>
		public DateTime? 日期 { get; set; }
		
		///<summary>
		///0:运行中；1停机中；2故障中
		///</summary>
		public string 状态 { get; set; }
		
	}
}
