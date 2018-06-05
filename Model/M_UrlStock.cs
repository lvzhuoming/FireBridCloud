/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：FireBridCloud
 *文件名：  UrlStock
 *创建人：  吕焯明
 *创建时间：2016-10-31 16:29:15
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-31 16:29:15
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_UrlStock
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
        /// 当前价
        /// </summary>
        public Double Price { get; set; }
        /// <summary>
        /// 最高价
        /// </summary>
        public Double HighestPrice { get; set; }
        /// <summary>
        /// 最低价
        /// </summary>
        public Double LowestPrice { get; set; }
        /// <summary>
        ///前一开盘日收盘价
        /// </summary>
        public Double YesterDayPrice { get; set; }
        /// <summary>
        /// 数据时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
