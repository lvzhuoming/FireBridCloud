/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Business
 *文件名：  HoldStock
 *创建人：  吕焯明
 *创建时间：2016-10-20 17:16:28
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-20 17:16:28
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Text;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data;
using DBUtility;
using Model;
namespace Business
{
    public partial class HistoryHoldStock
    {

        public static bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HistoryHoldStock");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(M_HoldStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HoldStock(");
            strSql.Append("StockNo,StockName,HoldAmount,Price,UpdateTime");
            strSql.Append(") values (");
            strSql.Append("@StockNo,@StockName,@HoldAmount,@Price,@UpdateTime");
            strSql.Append(") ");
            //strSql.Append(";select @@IDENTITY");
            OleDbParameter[] parameters = {
			            new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@HoldAmount", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Price", OleDbType.Double) ,            
                        new OleDbParameter("@UpdateTime", OleDbType.Date)                           
            };

            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.HoldAmount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.UpdateTime;

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
        public static bool Update(M_HoldStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [HoldStock] set ");

            strSql.Append("[StockNo]=@StockNo,");
            strSql.Append("[StockName]=@StockName,");
            strSql.Append("[HoldAmount]=@HoldAmount,");
            strSql.Append("[Price]=@Price,");
            strSql.Append("[UpdateTime]=@UpdateTime");
            strSql.Append(" where [ID]=@ID");

            OleDbParameter[] parameters = {           
                        new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@HoldAmount", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Price", OleDbType.Double) ,            
                        new OleDbParameter("@UpdateTime", OleDbType.Date),
                        new OleDbParameter("@ID", OleDbType.Integer,4) ,                     
            };
            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.HoldAmount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.ID;
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
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HoldStock ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;


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
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HoldStock ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
        public static M_HoldStock GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, StockNo, StockName, HoldAmount, Price, UpdateTime  ");
            strSql.Append("  from HoldStock ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;


            M_HoldStock model = new M_HoldStock();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.StockNo = ds.Tables[0].Rows[0]["StockNo"].ToString();
                model.StockName = ds.Tables[0].Rows[0]["StockName"].ToString();
                if (ds.Tables[0].Rows[0]["HoldAmount"].ToString() != "")
                {
                    model.HoldAmount = int.Parse(ds.Tables[0].Rows[0]["HoldAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = Double.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM HoldStock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM HoldStock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOleDb.Query(strSql.ToString());
        }
    }
}





