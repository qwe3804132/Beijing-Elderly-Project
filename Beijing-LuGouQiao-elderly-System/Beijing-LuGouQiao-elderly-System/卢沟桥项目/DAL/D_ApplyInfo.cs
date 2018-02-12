using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_ApplyInfo
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ApplyInfo");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            return DB.DbHelperSQL.Exists(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">申请信息</param>
        /// <returns>是否添加成功</returns>
        public bool Add(Model.ApplyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApplyInfo(");
            strSql.Append("UID,ApplyTime,Age,Gender,Address,Tel,Job,Money,Types)");
            strSql.Append(" values (");
            strSql.Append("@UID,@ApplyTime,@Age,@Gender,@Address,@Tel,@Job,@Money,@Types)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
                    new SqlParameter("@ApplyTime", SqlDbType.DateTime),
                    new SqlParameter("@Age", SqlDbType.Int),
                    new SqlParameter("@Gender", SqlDbType.VarChar,10),
                    new SqlParameter("@Address", SqlDbType.VarChar,30),
                    new SqlParameter("@Tel", SqlDbType.VarChar,30),
                    new SqlParameter("@Job", SqlDbType.VarChar,50),
                    new SqlParameter("@Money", SqlDbType.Float),
                    new SqlParameter("@Types", SqlDbType.Int)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.ApplyTime;
            parameters[2].Value = model.Age;
            parameters[3].Value = model.Gender;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Job;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Types;
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
        /// <param name="model">申请信息</param>
        /// <returns>是否更新成功</returns>
        public bool Update(Model.ApplyInfo model)
        {
            //ID,UID,ApplyTime,Age,Gender,Address,Tel,Job,Money,Types
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplyInfo set ");
            strSql.Append("UID=@UID,");
            strSql.Append("ApplyTime=@ApplyTime,");
            strSql.Append("Age=@Age,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Address=@Address,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Job=@Job,");
            strSql.Append("Money=@Money,");
            strSql.Append("Types=@Types");
            strSql.Append(" Where ID=@ID");
            

            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
                    new SqlParameter("@ApplyTime", SqlDbType.DateTime),
                    new SqlParameter("@Age", SqlDbType.Int),
                    new SqlParameter("@Gender", SqlDbType.VarChar,10),
                    new SqlParameter("@Address", SqlDbType.VarChar,30),
                    new SqlParameter("@Tel", SqlDbType.VarChar,30),
                    new SqlParameter("@Job", SqlDbType.VarChar,50),
                    new SqlParameter("@Money", SqlDbType.Float),
                    new SqlParameter("@Types", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.ApplyTime;
            parameters[2].Value = model.Age;
            parameters[3].Value = model.Gender;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.Job;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Types;
            parameters[9].Value = model.Id;

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
        /// 获取用户申请信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public Model.ApplyInfo GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from ApplyInfo ");
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
        public Model.ApplyInfo userInfo(int ID,int kind)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from ApplyInfo ");
            strSql.Append(" where UID=@UID and Types=@Types");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
                    new SqlParameter("@Types", SqlDbType.Int)                    };
            parameters[0].Value = ID;
            parameters[1].Value = kind;
            Model.ApplyInfo model = new Model.ApplyInfo();
            DataSet ds = DB.DbHelperSQL.Query(strSql.ToString(),parameters, DB.DbHelperSQL.maindataConnectionString);
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
        public Model.ApplyInfo DataRowToModel(DataRow row)
        {
            Model.ApplyInfo model = new Model.ApplyInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.Id = (int)row["ID"];
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = (int)row["UID"];
                }
                if (row["ApplyTime"] != null && row["ApplyTime"].ToString() !="")
                {
                    model.ApplyTime =  DateTime.Parse(row["ApplyTime"].ToString());
                }
                if (row["Gender"] != null && row["Gender"].ToString() != "")
                {
                    model.Gender = row["Gender"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Job"] != null)
                {
                    model.Job = row["Job"].ToString();
                }
                if (row["Money"] != null && row["Money"].ToString().Trim()!="")
                {
                    model.Money = Convert.ToSingle(row["Money"]);
                }
                if (row["Types"] != null && row["Money"].ToString().Trim() != "")
                {
                    model.Types = (int)row["Types"];
                }
                //if (row["Photo"] != null && row["Photo"].ToString().Trim() != "")
                //{
                //    model.Photo = (byte[])row["Photo"];
                //}
            }
            return model;
        }
    }
}