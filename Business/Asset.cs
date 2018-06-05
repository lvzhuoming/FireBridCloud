/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：Business
 *文件名：  Asset
 *创建人：  吕焯明
 *创建时间：2016-10-19 11:22:57
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-19 11:22:57
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using DBUtility;//Please add references
using Model;
namespace Business
{
	/// <summary>
	/// 数据访问类:M_Asset
	/// </summary>
	public partial class Asset
	{
		public Asset()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Asset");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public static bool Add(M_Asset model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Asset(");
			strSql.Append("Personal,Credit,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@Personal,@Credit,@UpdateTime)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Personal", OleDbType.Double),
					new OleDbParameter("@Credit", OleDbType.Double),
					new OleDbParameter("@UpdateTime", OleDbType.Date)};
			parameters[0].Value = model.Personal;
			parameters[1].Value = model.Credit;
			parameters[2].Value = model.UpdateTime;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
        public static bool Update(M_Asset model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Asset set ");
			strSql.Append("Personal=@Personal,");
			strSql.Append("Credit=@Credit,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Personal", OleDbType.Double),
					new OleDbParameter("@Credit", OleDbType.Double),
					new OleDbParameter("@UpdateTime", OleDbType.Date),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.Personal;
			parameters[1].Value = model.Credit;
			parameters[2].Value = model.UpdateTime;
			parameters[3].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Asset ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
        public static bool DeleteList(string IDlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Asset ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
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
        public static M_Asset GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Personal,Credit,UpdateTime from Asset ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			M_Asset model=new M_Asset();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public static M_Asset DataRowToModel(DataRow row)
		{
			M_Asset model=new M_Asset();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
                model.Personal = Convert.ToDouble(row["Personal"].ToString());
                model.Credit = Convert.ToDouble(row["Credit"].ToString());
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Personal,Credit,UpdateTime ");
			strSql.Append(" FROM Asset ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM Asset ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public static DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Asset T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "Asset";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

