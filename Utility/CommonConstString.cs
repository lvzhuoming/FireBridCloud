/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Utility
 *文件名：  CommonConstString
 *创建人：  吕焯明
 *创建时间：2016-10-19 9:46:25
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-19 9:46:25
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class CommonConstString
    {
        /// <summary>
        /// 数据库配置文件XML路径
        /// </summary>
        public static readonly string STR_ConfigPath = string.Format(System.Environment.CurrentDirectory) + "\\DataConn.xml";

        /// <summary>
        /// 数据库配置节点名
        /// </summary>
        public static readonly string STR_ConfigNode = "/Database/ConnectConfir/ConectString";

        /// <summary>
        /// 默认数据库路径
        /// </summary>
        public static readonly string STR_DefaultMdb=string.Format(System.Environment.CurrentDirectory) + "\\FireBridCloud.mdb";

        /// <summary>
        /// 默认数据库路径
        /// </summary>
        public static readonly string STR_DefaultMdbSqlite = string.Format(System.Environment.CurrentDirectory) + "\\Bank.db";
        /// <summary>
        /// 皮肤路径
        /// </summary>
        public static readonly string sskPath = string.Format(System.Environment.CurrentDirectory) + "\\ssk\\XPBlue.ssk";

        /// <summary>
        /// 皮肤路径
        /// </summary>
        public static readonly string imagePath = string.Format(System.Environment.CurrentDirectory) + "\\Image\\";

        /// <summary>
        /// K线图保存路径
        /// </summary>
        public static readonly string stockImagePath = string.Format(System.Environment.CurrentDirectory) + "\\Temp\\";
        /// <summary>
        /// 上证指数代码
        /// </summary>
        public static readonly string ShangHang= "000001";
        /// <summary>
        /// 深证指数代码
        /// </summary>
        public static readonly string ShenZhen = "399001";
        /// <summary>
        ///创业板指数代码
        /// </summary>
        public static readonly string ChuangYeBan = "399006";
    }

}
