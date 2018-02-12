using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //优待卡申请业务
    public class Card
    {
        private int id;
        private int uID;//申请者ID
        private int status;//0:一级失败 1：二级失败 2：三级失败 3：成功
        private int aNumber1;//二级审核员工号
        private int aNumber2;//三级审核员工号
        private string reason;//失败原因
        private int cardStatus;//优待卡状态 0：审核成功 1：制卡中 2：制卡完成待领取 3：已领取
        private DateTime getTimes;//优待卡领取时间

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


        public int CardStatus
        {
            get { return cardStatus; }
            set { cardStatus = value; }
        }


        public DateTime GetTimes
        {
            get { return getTimes; }
            set { getTimes = value; }
        }
    }
}