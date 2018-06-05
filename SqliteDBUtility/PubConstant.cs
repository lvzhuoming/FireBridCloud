using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqliteDBUtility
{
    class PubConstant
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnectionString
        {
            get
            {
                //string constr = "Data Source=WAIKIN\\SQLEXPRESS;Initial Catalog=stock;User ID=sa1;password=lv123456";
                string constr = @"Data Source=devserver;Initial Catalog=Stock;User ID=dbadmin;password=P@ssw0rd8899";
                return constr;
            }
        }
    }
}
