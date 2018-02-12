using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_MoneyRecord
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from moneyRecord");
            strSql.Append(" where ");
            strSql.Append(strWhere);
            return DB.DbHelperSQL.Exists(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="strWhere">判断条件</param>
        /// <returns>结果 是否存在</returns>
        public bool search(int UID,int month)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from moneyRecord");
            strSql.Append(" where UID=");
            strSql.Append(UID);
            strSql.Append(" and datepart(MONTH,Time)=");
            strSql.Append(month);
            /*SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
                    new SqlParameter("@month", SqlDbType.Int),
                    };*/
            //parameters[0].Value = UID;
            //parameters[1].Value = month;
            return DB.DbHelperSQL.Exists(strSql.ToString(), DB.DbHelperSQL.maindataConnectionString);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">申请信息</param>
        /// <returns>是否添加成功</returns>
        public bool Add(Model.MoneyRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into moneyRecord(");
            strSql.Append("UID,ANumber,Time,Money)");
            strSql.Append(" values (");
            strSql.Append("@UID,@ANumber,@Time,@Money)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int),
                    new SqlParameter("@ANumber", SqlDbType.Int),
                    new SqlParameter("@Time", SqlDbType.DateTime),
                    new SqlParameter("@Money", SqlDbType.Float)
                    };
            parameters[0].Value = model.UID;
            parameters[1].Value = model.ANumber;
            parameters[2].Value = model.Time;
            parameters[3].Value = model.Money;
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