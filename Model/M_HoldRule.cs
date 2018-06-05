/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Model
 *文件名：  M_HoldRule
 *创建人：  吕焯明
 *创建时间：2016-10-13 16:52:38
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-13 16:52:38
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
namespace Model
{
    /// <summary>
    /// HoldRule:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class M_HoldRule
    {
        #region Model
        private int _id;
        private double _lowprice;
        private double _hightprice;
        private double _nowprice;
        private DateTime _updatetime;
        /// <summary>
        /// 表ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 上证指数最低价
        /// </summary>
        public double LowPrice
        {
            set { _lowprice = value; }
            get { return _lowprice; }
        }
        /// <summary>
        /// 上证指数最高价
        /// </summary>
        public double HightPrice
        {
            set { _hightprice = value; }
            get { return _hightprice; }
        }
        /// <summary>
        /// 上证指数当前价
        /// </summary>
        public double NowPrice
        {
            set { _nowprice = value; }
            get { return _nowprice; }
        }
        /// <summary>
        /// 指数更新日期
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}

