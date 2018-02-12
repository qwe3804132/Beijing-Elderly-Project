using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_AdminInfo
    {
        DAL.D_AdminInfo d_admin=new DAL.D_AdminInfo();
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name">用户名-工号</param>
        /// <param name="password">密码</param>
        /// <returns>返回ID和管理员类别 ID  -1：不存在用户 0：密码错误  类别 0：社区 1：街道 2：总管理员</returns>
        public int[] login(string number, string password)
        {
            int[] idAndTypes = new int[2];
            if (d_admin.Exists("Number='" + number + "'"))
            {
                Model.AdminInfo model = d_admin.GetModel("Number='" + number + "' and PWD='" + password + "'");
                if (model != null)
                {
                    idAndTypes[0] = model.Id;
                    idAndTypes[1] = model.Types;
                    
                }
                else
                {
                    idAndTypes[0] = 0;
                    idAndTypes[1] = 0;
                }

            }
            else
            {
                idAndTypes[0] = -1;
                idAndTypes[1] = 0;
            }
            return idAndTypes;
        }

        public Model.AdminInfo GetAdminInfo(string name, string Number)
        {
            return d_admin.GetModel("Name='"+name+"' and Number="+Number);
        }
        public Model.AdminInfo GetAdminInfo(int id)
        {
            return d_admin.GetModel("ID=" + id);
        }
        public bool InsertAdmin(Model.AdminInfo admin)
        {
            return d_admin.Add(admin);
        }
        public bool ChangePWD(string pwd, int uid)
        {
            DB.DbHelperSQL.ExecuteSql("update AdminInfo set PWD='" + pwd + "' where ID=" + uid, DB.DbHelperSQL.maindataConnectionString);
            return true;
        }
    }
}