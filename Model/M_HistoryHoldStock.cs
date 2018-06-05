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
	public class M_HistroyHoldStock
	{
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockNo { get; set; }
        /// <summary>
        ///股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        ///持仓单位股数 
        /// </summary>
        public int HoldAmount { get; set; }
        /// <summary>
        ///持有的最低价
        /// </summary>
        public double BasePrice { get; set; }
        /// <summary>
        ///最后持有时间
        /// </summary>
        public string HoldDate { get; set; }
	}
}


