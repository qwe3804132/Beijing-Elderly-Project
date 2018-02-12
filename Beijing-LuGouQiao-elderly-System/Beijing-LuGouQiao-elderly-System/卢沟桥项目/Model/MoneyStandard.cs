using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.Model
{
    //津贴标准
    public class MoneyStandard
    {
        private int id;
        private int minAge;//最小年龄
        private int maxAge;//最大年龄
        private float money;//津贴金额标准

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public int MinAge
        {
            get { return minAge; }
            set { minAge = value; }
        }
        

        public int MaxAge
        {
            get { return maxAge; }
            set { maxAge = value; }
        }
        

        public float Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}