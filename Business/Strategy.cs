/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Business
 *文件名：  Strategy
 *创建人：  吕焯明
 *创建时间：2016-12-13 17:07:37
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-12-13 17:07:37
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using DBUtility;
using Model;

namespace Business
{
    public class Strategy
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Strategy");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public static bool Delete(string stockNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Strategy ");
            strSql.Append(" where StockNo=@StockNo");
            OleDbParameter[] parameters = {
					new OleDbParameter("@StockNo", OleDbType.VarChar)
			};
            parameters[0].Value = stockNo;


            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(MStrategy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Strategy(");
            strSql.Append("StockNo,StockName,Price,Amount,HoldFlag,BasePoint");
            strSql.Append(") values (");
            strSql.Append("@StockNo,@StockName,@Price,@Amount,@HoldFlag,@BasePoint");
            strSql.Append(") ");
            //strSql.Append(";select @@IDENTITY");
            OleDbParameter[] parameters = {
			            new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,                     
                        new OleDbParameter("@Price", OleDbType.Double) ,
                        new OleDbParameter("@Amount", OleDbType.Integer,4) ,   
                        new OleDbParameter("@HoldFlag", OleDbType.Boolean) ,                          
                        new OleDbParameter("@BasePoint", OleDbType.Boolean) 
            };

            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.HoldFlag;
            parameters[5].Value = model.BasePoint;
            //parameters[6].Value = model.ID;

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(MStrategy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Strategy] set ");

            strSql.Append("[StockNo]=@StockNo,");
            strSql.Append("[StockName]=@StockName,");
            strSql.Append("[Price]=@Price,");
            strSql.Append("[Amount]=@Amount,");
            strSql.Append("[HoldFlag]=@HoldFlag");
            strSql.Append("[BasePoint]=@BasePoint");
            strSql.Append(" where [ID]=@ID");

            OleDbParameter[] parameters = {           
                        new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@Price", OleDbType.Double,4) ,            
                        new OleDbParameter("@Amount", OleDbType.Integer) ,            
                        new OleDbParameter("@HoldFlag", OleDbType.Boolean),
                        new OleDbParameter("@BasePoint", OleDbType.Boolean) , 
                        new OleDbParameter("@ID", OleDbType.Integer)
            };
            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.HoldFlag;
            parameters[6].Value = model.ID;
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static MStrategy GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, StockNo, StockName,Price,Amount,HoldFlag,BasePoint ");
            strSql.Append("  from Strategy ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;


            MStrategy model = new MStrategy();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.StockNo = ds.Tables[0].Rows[0]["StockNo"].ToString();
                model.StockName = ds.Tables[0].Rows[0]["StockName"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = Double.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = int.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HoldFlag"].ToString() != "")
                {
                    model.HoldFlag = Boolean.Parse(ds.Tables[0].Rows[0]["HoldFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BasePoint"].ToString() != "")
                {
                    model.BasePoint = Boolean.Parse(ds.Tables[0].Rows[0]["BasePoint"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
