using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_MoneyRecord
    {
        DAL.D_MoneyRecord d_moneyRecord = new DAL.D_MoneyRecord();
        Model.MoneyRecord model = new Model.MoneyRecord();

        /// <summary>
        ///表中添加一条数据
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool AddRecord(int UID, int ANumber,float money)
        {
            model.UID = UID;
            model.ANumber = ANumber;
            model.Money = money;
            model.Time = DateTime.Now.Date;
            return d_moneyRecord.Add(model);
        }
        public bool search(int UID, int mounth)
        {
            return d_moneyRecord.search(UID,mounth);
        }
       
    }
}