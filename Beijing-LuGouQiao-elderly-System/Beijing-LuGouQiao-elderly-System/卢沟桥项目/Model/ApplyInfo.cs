using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //申请填写个人信息
    public class ApplyInfo
    {
        private int id;//ID
        private int uID;//申请者ID
        private DateTime applyTime;//申请时间
        private int age;//申请者年龄
        private string gender;//申请者性别
        private string address;//家庭住址
        private string tel;//电话
        private string job;//退休前工作
        private float money;//退休金
        private int types;//申请类别 0：优待卡 1：老年津贴
        private byte[] photo;//照片

        
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

        public DateTime ApplyTime
        {
            get { return applyTime; }
            set { applyTime = value; }
        }
        

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        

        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        

        public float Money
        {
            get { return money; }
            set { money = value; }
        }
        

        public int Types
        {
            get { return types; }
            set { types = value; }
        }
        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }
    }
}