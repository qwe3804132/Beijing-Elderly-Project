using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_Community
    {
        DAL.D_Community d_com = new DAL.D_Community();
        public string GetCommunityName(int CommunityID)
        {
            return d_com.GetName(CommunityID);
        }
    }
}