/************************************************************************************
 * Copyright (c) 2017  All Rights Reserved.
 *命名空间：Business
 *文件名：  ExpectStock
 *创建人：  吕焯明
 *创建时间：2017-02-20 15:23:59
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2017-02-20 15:23:59
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
    public static class ExpectStock
    {
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExpectStock");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;
            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(string stockNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ExpectStock");
            strSql.Append(" where ");
            strSql.Append(" StockNo = @StcokNo  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@StcokNo", OleDbType.VarChar,10)
			};
            parameters[0].Value = stockNo;
            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(M_ExpectStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ExpectStock(");
            strSql.Append("StockNo,StockName,Price,ExpectPrice,UpdateTime,OrderIndex");
            strSql.Append(") values (");
            strSql.Append("@StockNo,@StockName,@Price,@ExpectPrice,@UpdateTime,@OrderIndex");
            strSql.Append(") ");
            //strSql.Append(";select @@IDENTITY");
            OleDbParameter[] parameters = {
			            new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@Price", OleDbType.Double) ,            
                        new OleDbParameter("@ExpectPrice", OleDbType.Double) ,            
                        new OleDbParameter("@UpdateTime", OleDbType.Date),
                        new OleDbParameter("@OrderIndex",OleDbType.Integer)
            };

            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.ExpectPrice;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.OrderIndex;
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
        public static bool Update(M_ExpectStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ExpectStock] set ");

            strSql.Append("[StockNo]=@StockNo,");
            strSql.Append("[StockName]=@StockName,");
            strSql.Append("[Price]=@Price,");
            strSql.Append("[ExpectPrice]=@ExpectPrice,");
            strSql.Append("[UpdateTime]=@UpdateTime,");
            strSql.Append("[OrderIndex]=@OrderIndex");
            strSql.Append(" where [ID]=@ID");

            OleDbParameter[] parameters = {           
                        new OleDbParameter("@StockNo", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@StockName", OleDbType.VarChar,255) ,            
                        new OleDbParameter("@Price", OleDbType.Double) ,            
                        new OleDbParameter("@ExpectPrice", OleDbType.Double) ,            
                        new OleDbParameter("@UpdateTime", OleDbType.Date),
                        new OleDbParameter("@OrderIndex", OleDbType.Integer),
                        new OleDbParameter("@ID", OleDbType.Integer,4) ,                     
            };
            parameters[0].Value = model.StockNo;
            parameters[1].Value = model.StockName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.ExpectPrice;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.OrderIndex;
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
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ExpectStock ");
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
            strSql.Append("delete from ExpectStock ");
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
        public static M_ExpectStock GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, StockNo, StockName, Price, ExpectPrice, UpdateTime,OrderIndex  ");
            strSql.Append("  from ExpectStock ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;


            M_ExpectStock model = new M_ExpectStock();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.StockNo = ds.Tables[0].Rows[0]["StockNo"].ToString();
                model.StockName = ds.Tables[0].Rows[0]["StockName"].ToString();
                if (ds.Tables[0].Rows[0]["ExpectPrice"].ToString() != "")
                {
                    model.ExpectPrice = Double.Parse(ds.Tables[0].Rows[0]["ExpectPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = Double.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
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
            strSql.Append(" FROM ExpectStock ");
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
            strSql.Append(" FROM ExpectStock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOleDb.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static M_ExpectStock DataRowToModel(DataRow row)
        {
            M_ExpectStock model = new M_ExpectStock();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                model.StockNo = row["StockNo"].ToString();
                model.StockName = row["StockName"].ToString();
                if (row["ExpectPrice"].ToString() != "")
                {
                    model.ExpectPrice = Double.Parse(row["ExpectPrice"].ToString());
                }
                if (row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["Price"].ToString() != "")
                {
                    model.Price = Double.Parse(row["Price"].ToString());
                }
                if (row["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(row["OrderIndex"].ToString());
                }
            }
            return model;
        }
    }
}
