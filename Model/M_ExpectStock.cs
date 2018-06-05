/************************************************************************************
 * Copyright (c) 2017  All Rights Reserved.
 *命名空间：Model
 *文件名：  M_ExpectStock
 *创建人：  吕焯明
 *创建时间：2017-02-20 15:03:44D:\Code\FireBridCloud\Business\Asset.cs
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2017-02-20 15:03:44
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_ExpectStock
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockNo { get; set; }
        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 当前股价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 期望价格
        /// </summary>
        public double ExpectPrice { get; set; }
        /// <summary>
        /// 股票最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int OrderIndex { get; set; }

    }
}
