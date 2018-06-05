using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace SqliteDBUtility
{
    class SqlitePubConstant
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnectionString
        {
            get
            {
                //string constr = "Data Source=WAIKIN\\SQLEXPRESS;Initial Catalog=stock;User ID=sa1;password=lv123456";
                string constr = string.Format("Data Source={0}", CommonConstString.STR_DefaultMdbSqlite);
                return constr;
            }
        }
    }
}
