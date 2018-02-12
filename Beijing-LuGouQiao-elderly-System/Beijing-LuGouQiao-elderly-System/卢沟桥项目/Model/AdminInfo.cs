using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //管理员
    public class AdminInfo
    {
        private int id;//管理员ID
        private string name;//姓名
        private int number;//工号
        private string pWD;//密码
        private int communityID;//所属社区ID
        private int types;//管理员类型 0 社区 1 街道 2 总管理员
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        

        public string PWD
        {
            get { return pWD; }
            set { pWD = value; }
        }
        

        public int CommunityID
        {
            get { return communityID; }
            set { communityID = value; }
        }
        

        public int Types
        {
            get { return types; }
            set { types = value; }
        }
    }
}