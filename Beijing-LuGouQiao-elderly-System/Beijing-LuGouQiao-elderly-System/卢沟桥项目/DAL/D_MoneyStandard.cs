using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_MoneyStandard
    {
        /// <summary>
        /// 获取津贴标准
        /// </summary>
        /// <param name="Age">申请者年龄</param>
        /// <returns>津贴ID</returns>
        public int GetStandard(int Age)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from MoneyStandard ");
            strSql.Append(" where MinAge<= @Age and MaxAge>= @Age");
            SqlParameter[] parameters = {
					new SqlParameter("@Age", SqlDbType.Int)};
            parameters[0].Value = Age;
            object obj =  DB.DbHelperSQL.GetSingle(strSql.ToString(), parameters, DB.DbHelperSQL.maindataConnectionString);
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }

        }
    }
}