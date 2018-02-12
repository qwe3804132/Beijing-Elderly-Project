using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    public class MoneyRecord
    {
        private int id;
        private int uID;//领取人ID
        private int aNumber;//操作员工号
        private DateTime time;//操作时间
        private float money;//领取金额

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
        

        public int ANumber
        {
            get { return aNumber; }
            set { aNumber = value; }
        }
        

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
       

        public float Money
        {
            get { return money; }
            set { money = value; }
        }
        



    }
}