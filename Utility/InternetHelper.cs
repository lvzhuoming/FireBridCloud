/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Utility
 *文件名：  GetUrlString
 *创建人：  吕焯明
 *创建时间：2016-10-24 16:53:12
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-24 16:53:12
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;


namespace Utility
{
    public class InternetHelper
    {
        /// <summary> 
        /// Get方式获取url地址输出内容 
        /// </summary> /// <param name="url">url</param> 
        /// <param name="encoding">返回内容编码方式，例如：Encoding.UTF8</param> 
        public static string SendRequest(String url, Encoding encoding)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
                return sr.ReadToEnd();
            }
            catch(Exception ex)
            {
                return "";
            }

        }

        /// <summary>
        /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败 
        /// </summary>
        /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
        /// <returns></returns>
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
