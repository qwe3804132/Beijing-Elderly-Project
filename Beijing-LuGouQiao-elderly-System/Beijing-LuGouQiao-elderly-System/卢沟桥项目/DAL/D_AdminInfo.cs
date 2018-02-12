using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_AdminInfo
    {
          /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool Exists(string strWhere)
        { 
            StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AdminInfo");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            return DB.DbHelperSQL.Exists(strSql.ToString(),DB.DbHelperSQL.maindataConnectionString);
        }
       /// <summary>
        /// 增加一条数据
       /// </summary>
       /// <param name="model">信息</param>
       /// <returns>是否添加成功</returns>
        public bool Add(Model.AdminInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminInfo(");
            strSql.Append("Name,Number,PWD,CommunityID,Types)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Number,@PWD,@CommunityID,@Types)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Number",SqlDbType.NVarChar,30),
                    new SqlParameter("@PWD",SqlDbType.NVarChar,30),
                    new SqlParameter("@CommunityID", SqlDbType.Int),
                    new SqlParameter("@Types", SqlDbType.Int)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.PWD;
            parameters[3].Value = model.CommunityID;
            parameters[4].Value = model.Types;

            int rows = DB.DbHelperSQL.ExecuteSql(strSql.ToString(), parameters, DB.DbHelperSQL.maindataConnectionString);
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
        /// <param name="model">信息</param>
        /// <returns>是否更新成功</returns>
        public bool Update(Model.AdminInfo model)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminInfo set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Number=@Number,");
            strSql.Append("PWD=@PWD,");
            strSql.Append("CommunityID=@CommunityID");
            strSql.Append("Types=@Types");
            strSql.Append(" Where ID=@ID");

            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Number",SqlDbType.NVarChar,30),
                    new SqlParameter("@PWD",SqlDbType.NVarChar,30),
                    new SqlParameter("@CommunityID", SqlDbType.Int),
                    new SqlParameter("@Types", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.PWD;
            parameters[3].Value = model.CommunityID;
            parameters[4].Value = model.Types;
            parameters[5].Value = model.Id;
           
            int rows = DB.DbHelperSQL.ExecuteSql(strSql.ToString(), parameters, DB.DbHelperSQL.maindataConnectionString);
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
        /// <param name="id">ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminInfo ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;
           
            int rows = DB.DbHelperSQL.ExecuteSql(strSql.ToString(), parameters, DB.DbHelperSQL.maindataConnectionString);
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
        /// <param name="id">ID</param>
        /// <returns>信息</returns>
        public Model.AdminInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from AdminInfo ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;

            Model.AdminInfo model = new Model.AdminInfo();
            DataSet ds = DB.DbHelperSQL.Query(strSql.ToString(), parameters, DB.DbHelperSQL.maindataConnectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public Model.AdminInfo GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from AdminInfo ");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            Model.AdminInfo model = new Model.AdminInfo();
            DataSet ds = DB.DbHelperSQL.Query(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.AdminInfo DataRowToModel(DataRow row)
        {
            //Name,Number,PWD,CommunityID,Types
            Model.AdminInfo model = new Model.AdminInfo();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.Id = (int)row["ID"];
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Number"] != null)
                {
                    model.Number = (int)row["Number"];
                }
                if (row["PWD"] != null)
                {
                    model.PWD = (string)row["PWD"];
                }
                if (row["CommunityID"] != null && row["CommunityID"].ToString()!="")
                {
                    model.CommunityID = (int)row["CommunityID"];
                }
                if (row["Types"] != null)
                {
                    model.Types = (int)row["Types"];
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AdminInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.DbHelperSQL.Query(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
    }
    
}