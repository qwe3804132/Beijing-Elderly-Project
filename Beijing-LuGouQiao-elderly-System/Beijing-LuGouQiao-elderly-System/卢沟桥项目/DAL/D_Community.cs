using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 卢沟桥项目.DAL
{
    public class D_Community
    {
        public string GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CommunityName from Community");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = id;
            object obj = DB.DbHelperSQL.GetSingle(strSql.ToString(),parameters, DB.DbHelperSQL.maindataConnectionString);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}