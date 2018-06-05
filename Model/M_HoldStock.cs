/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Model
 *文件名：  M_HoldStock
 *创建人：  吕焯明
 *创建时间：2016-10-20 16:59:54
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-20 16:59:54
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
namespace Model
{
	/// <summary>
	/// M_HoldStock:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class M_HoldStock
	{
		public M_HoldStock()
		{}
		#region Model
		private int _id;
		private string _stockno;
		private string _stockname;
		private int _holdamount;
		private double _price;
		private DateTime _updatetime;
		/// <summary>
		/// 自动增长ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 股票代码
		/// </summary>
		public string StockNo
		{
			set{ _stockno=value;}
			get{return _stockno;}
		}
		/// <summary>
		/// 股票名称
		/// </summary>
		public string StockName
		{
			set{ _stockname=value;}
			get{return _stockname;}
		}
		/// <summary>
		/// 持仓股数
		/// </summary>
		public int HoldAmount
		{
			set{ _holdamount=value;}
			get{return _holdamount;}
		}
		/// <summary>
		/// 股价
		/// </summary>
		public double Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 更新日期
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}


