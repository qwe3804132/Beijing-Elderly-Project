using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //社区
    public class Community
    {
        private int id;//社区ID
        private string communityName;//社区名

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string CommunityName
        {
            get { return communityName; }
            set { communityName = value; }
        }
    }
}