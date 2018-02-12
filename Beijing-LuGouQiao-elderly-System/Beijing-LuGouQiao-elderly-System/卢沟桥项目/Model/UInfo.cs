using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //申请者信息
    public class UInfo
    {
        private int id;//申请者ID
        private string name;//姓名
        private string number;//身份证号
        private DateTime birthday;//出生日期
        private int communityID;//所属社区ID 
        private string pWD;//密码

        

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
        

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        

        public int CommunityID
        {
            get { return communityID; }
            set { communityID = value; }
        }
        public string PWD
        {
            get { return pWD; }
            set { pWD = value; }
        }
    }
}