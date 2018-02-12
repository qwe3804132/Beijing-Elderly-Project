using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_UInfo
    {
        DAL.D_UInfo d_UInfo = new DAL.D_UInfo();

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="password">密码-身份证后六位</param>
        /// <returns>返回ID 若为-1则不存在用户 0密码错误</returns>
        public int login(string name, string pWD)
        {
            if (d_UInfo.Exists("Name='" + name+"'"))
            {
                Model.UInfo model = d_UInfo.GetModel("Name='" + name + "' and PWD='" + pWD+"'");
                if (model != null)
                {
                    return model.Id;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        public Model.UInfo GetUInfo(int UID)
        {
            return d_UInfo.GetModel(UID);
        }

       
    }
}