using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //老年津贴申请业务
    public class Money
    {
        private int id;
        private int uID;//申请者ID
        private int mID;//津贴类别ID
        private int status;//申请状态
        private int aNumber1;//二级审核员工号
        private int aNumber2;//三级审核员工号
        private string reason;//失败原因
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }
        

        public int MID
        {
            get { return mID; }
            set { mID = value; }
        }
        

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        

        public int ANumber1
        {
            get { return aNumber1; }
            set { aNumber1 = value; }
        }
        

        public int ANumber2
        {
            get { return aNumber2; }
            set { aNumber2 = value; }
        }
        

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}