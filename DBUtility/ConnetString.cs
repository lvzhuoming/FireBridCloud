/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：DBUtility
 *文件名：  ConnetString
 *创建人：  吕焯明
 *创建时间：2016-10-13 17:26:58
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-13 17:26:58
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Office.Interop.Access;
using Utility;
namespace DBUtility
{
    public class ConnetString
    {
        public static string GetDbConnetString()
        {
            string constr = "";
            string dbPath = "";
            XmlDocument dbxml = new XmlDocument();
            dbxml.Load(CommonConstString.STR_ConfigPath);
            XmlNodeList nodeList = dbxml.SelectNodes(CommonConstString.STR_ConfigNode);
            if(nodeList!=null&&nodeList.Count>0)
                dbPath = nodeList[0].InnerText;
            if(!File.Exists(dbPath))
                dbPath = CommonConstString.STR_DefaultMdb;
            return GetAccessVersionConStr(dbPath);
        }

        /// <summary>
        /// 根据Access版本构建连接字符串
        /// </summary>
        /// <param name="daPath"></param>
        /// <returns></returns>
        public static  string GetAccessVersionConStr(string dbPath)
        {
            string constr = "";
            Microsoft.Office.Interop.Access.Application excelApp = new Microsoft.Office.Interop.Access.Application();
            string accessVersion = excelApp.Version;
            switch (accessVersion)
            {
                case "4.0":
                    constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}'", dbPath);
                    break;
                default:
                    constr = string.Format(@"Provider=microsoft.ace.oledb.12.0;Data Source='{0}'", dbPath);
                    //constr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}'", daPath);
                    break;
            }
            return constr;
        }

        public static bool AccessExist()
        {
            string constr = "";
            try
            {
                Microsoft.Office.Interop.Access.Application excelApp = new Microsoft.Office.Interop.Access.Application();
                string accessVersion = excelApp.Version;
                if (accessVersion == "12.0" || accessVersion == "14.0" || accessVersion == "4.0")
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
    }
}
