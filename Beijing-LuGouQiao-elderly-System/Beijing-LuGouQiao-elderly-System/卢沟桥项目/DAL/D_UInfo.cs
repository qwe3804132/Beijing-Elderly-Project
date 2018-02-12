using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_UInfo
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool Exists(string strWhere)
        { 
            StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UInfo");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            return DB.DbHelperSQL.Exists(strSql.ToString(),DB.DbHelperSQL.maindataConnectionString);
        }
       /// <summary>
        /// 增加一条数据
       /// </summary>
       /// <param name="model">申请者信息</param>
       /// <returns>是否添加成功</returns>
        public bool Add(Model.UInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UInfo(");
            strSql.Append("Name,Number,Birthday,CommunityID,PWD)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Number,@Birthday,@CommunityID,@PWD)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Number",SqlDbType.NVarChar,18),
                    new SqlParameter("@Birthday",SqlDbType.DateTime),
                    new SqlParameter("@CommunityID", SqlDbType.Int),
                    new SqlParameter("@PWD", SqlDbType.Char,6)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Birthday;
            parameters[3].Value = model.CommunityID;
            parameters[4].Value = model.PWD;

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
        /// <param name="model">申请者信息</param>
        /// <returns>是否更新成功</returns>
        public bool Update(Model.UInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UInfo set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Number=@Number,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("CommunityID=@CommunityID");
            strSql.Append("PWD=@PWD");
            strSql.Append(" Where ID=@ID");

            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,30),
					new SqlParameter("@Number",SqlDbType.NVarChar,18),
                    new SqlParameter("@Birthday",SqlDbType.DateTime),
                    new SqlParameter("@CommunityID", SqlDbType.Int),
                    new SqlParameter("@PWD", SqlDbType.Char,6),
                    new SqlParameter("@ID", SqlDbType.Int),};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Birthday;
            parameters[3].Value = model.CommunityID;
            parameters[4].Value = model.PWD;
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
        /// <param name="id">申请人ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UInfo ");
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
        /// <param name="id">申请人ID</param>
        /// <returns>申请人信息</returns>
        public Model.UInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from UInfo ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;

            Model.UInfo model = new Model.UInfo();
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
        public Model.UInfo GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from UInfo ");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            Model.UInfo model = new Model.UInfo();
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
        public Model.UInfo DataRowToModel(DataRow row)
        {
            Model.UInfo model = new Model.UInfo();
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
                    model.Number = row["Number"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["CommunityID"] != null)
                {
                    model.CommunityID = (int)row["CommunityID"];
                }
                if (row["PWD"] != null)
                {
                    model.PWD = row["PWD"].ToString();
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
            strSql.Append(" FROM UInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.DbHelperSQL.Query(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
    }
}