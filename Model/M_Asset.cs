/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Model
 *文件名：  M_Asset
 *创建人：  吕焯明
 *创建时间：2016-10-19 11:21:54
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-19 11:21:54
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
namespace Model
{
	/// <summary>
	/// M_Asset:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class M_Asset
	{
		public M_Asset()
		{}
		#region Model
		private int _id;
		private double _personal;
		private double _credit;
		private DateTime _updatetime;
		/// <summary>
		/// 自增长ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 个人资产
		/// </summary>
		public double Personal
		{
			set{ _personal=value;}
			get{return _personal;}
		}
		/// <summary>
		/// 信用资产
		/// </summary>
		public double Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// 资产更新日期
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

