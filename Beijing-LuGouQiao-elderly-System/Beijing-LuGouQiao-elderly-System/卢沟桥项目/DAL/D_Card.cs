using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_Card
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Card");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            return DB.DbHelperSQL.Exists(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">申请者信息</param>
        /// <returns>是否添加成功</returns>
        public bool Add(Model.Card model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Card(");
            strSql.Append("UID,Status,ANumber1,ANumber2,Reason,CardStatus,GetTimes)");
            strSql.Append(" values (");
            strSql.Append("@UID,@Status,@ANumber1,@ANumber2,@Reason,@CardStatus,@GetTimes)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
					new SqlParameter("@Status",SqlDbType.Int),
                    new SqlParameter("@ANumber1",SqlDbType.Int),
                    new SqlParameter("@ANumber2", SqlDbType.Int),
                    new SqlParameter("@Reason", SqlDbType.VarChar,500),
                    new SqlParameter("@CardStatus", SqlDbType.Int),  
                    new SqlParameter("@GetTimes", SqlDbType.DateTime)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.ANumber1;
            parameters[3].Value = model.ANumber2;
            parameters[4].Value = model.Reason;
            parameters[5].Value = model.CardStatus;
            parameters[6].Value = model.GetTimes;

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
        public bool Update(Model.Card model)
        {
            //UID,Status,ANumber1,ANumber2,Reason,CardStatus,GetTimes
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("UID=@UID,");
            strSql.Append("Status=@Status,");
            strSql.Append("ANumber1=@ANumber1,");
            strSql.Append("ANumber2=@ANumber2,");
            strSql.Append("Reason=@Reason,");
            strSql.Append("CardStatus=@CardStatus,");
            strSql.Append("GetTimes=@GetTimes");
            strSql.Append(" Where ID=@ID");

            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
					new SqlParameter("@Status",SqlDbType.Int),
                    new SqlParameter("@ANumber1",SqlDbType.Int),
                    new SqlParameter("@ANumber2", SqlDbType.Int),
                    new SqlParameter("@Reason", SqlDbType.VarChar,500),
                    new SqlParameter("@CardStatus", SqlDbType.Int),  
                    new SqlParameter("@GetTimes", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int)                  };
            parameters[0].Value = model.UID;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.ANumber1;
            parameters[3].Value = model.ANumber2;
            parameters[4].Value = model.Reason;
            parameters[5].Value = model.CardStatus;
            parameters[6].Value = model.GetTimes;
            parameters[7].Value = model.Id;

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
        /// 更新审核状态
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool updateStatus(int UID, int Status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("Status=@Status");
            strSql.Append(" Where UID=@UID");

            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
					new SqlParameter("@Status",SqlDbType.Int)};
            parameters[0].Value = UID;
            parameters[1].Value = Status;

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


        public bool updateCardStatus(int ID, int CardStatus)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("CardStatus=@CardStatus");
            strSql.Append(" Where ID=@ID");

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int),
					new SqlParameter("@CardStatus",SqlDbType.Int)};
            parameters[0].Value = ID;
            parameters[1].Value = CardStatus;

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
            strSql.Append("delete from Card ");
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
        public Model.Card GetModel(int uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Card ");
            strSql.Append(" where UID=@UID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int)};
            parameters[0].Value = uid;

            Model.Card model = new Model.Card();
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
        public Model.Card GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Card ");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            Model.Card model = new Model.Card();
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
        public Model.Card DataRowToModel(DataRow row)
        {
            //ID,UID,Status,ANumber1,ANumber2,Reason,CardStatus,GetTimes
            Model.Card model = new Model.Card();
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
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status =(int)row["Status"];
                }
                if (row["ANumber1"] != null && row["ANumber1"].ToString() != "")
                {
                    model.ANumber1 = (int)row["ANumber1"];
                }
                if (row["ANumber2"] != null && row["ANumber2"].ToString() != "")
                {
                    model.ANumber2 = (int)row["ANumber2"];
                }
                if (row["Reason"] != null)
                {
                    model.Reason = row["Reason"].ToString();
                }
                if (row["CardStatus"] != null && row["CardStatus"].ToString() != "")
                {
                    model.CardStatus = (int)row["CardStatus"];
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
            strSql.Append(" FROM Card ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.DbHelperSQL.Query(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
        public bool update(Model.Card card)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("Reason=@Reason,");
            strSql.Append("ANumber2=@ANumber2,");
            strSql.Append("Status=@Status,");
            strSql.Append("CardStatus=@CardStatus");
            strSql.Append(" where ");
            strSql.Append("UID=@UID");
            SqlParameter[] parameters = {
					new SqlParameter("@Reason", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@ANumber2", SqlDbType.Int),
                    new SqlParameter("@CardStatus", SqlDbType.Int),
                    new SqlParameter("@UID", SqlDbType.Int)};
            parameters[0].Value = card.Reason;
            parameters[1].Value = card.Status;
            parameters[2].Value = card.ANumber2;
            parameters[3].Value = card.CardStatus;
            parameters[4].Value = card.UID;
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
        public bool update1(Model.Card card)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("Reason=@Reason,");
            strSql.Append("ANumber1=@ANumber1,");
            strSql.Append("Status=@Status,");
            strSql.Append("CardStatus=@CardStatus");
            strSql.Append(" where ");
            strSql.Append("ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Reason", SqlDbType.VarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@ANumber1", SqlDbType.Int),
                    new SqlParameter("@CardStatus", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = card.Reason;
            parameters[1].Value = card.Status;
            parameters[2].Value = card.ANumber1;
            parameters[3].Value = card.CardStatus;
            parameters[4].Value = card.Id;
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
        public bool UpdateByStatusAndType(int status,int cardStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Card set ");
            strSql.Append("CardStatus=@CardStatus");
            strSql.Append(" where ");
            strSql.Append("Status=@Status AND ");
            strSql.Append("CardStatus=@CardStatusS");
            SqlParameter[] parameters = {
					new SqlParameter("@CardStatus", SqlDbType.Int),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@CardStatusS", SqlDbType.Int)
                    };
            parameters[0].Value = cardStatus;
            parameters[1].Value = status;
            parameters[2].Value = 1;
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
    }
}