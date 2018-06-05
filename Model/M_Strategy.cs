/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Model
 *文件名：  M_Strategy
 *创建人：  吕焯明
 *创建时间：2016-12-13 16:58:48
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-12-13 16:58:48
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class MStrategy
    {
        public int ID { get; set; }
        public string StockNo { get; set; }
        public string StockName { get; set; }
        public Double Price { get; set; }
        public int Amount { get; set; }
        public bool HoldFlag { get; set; }
        public bool BasePoint { get; set; }
    }
}
