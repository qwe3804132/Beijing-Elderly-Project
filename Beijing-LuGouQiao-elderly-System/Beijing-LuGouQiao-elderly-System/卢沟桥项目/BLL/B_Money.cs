using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_Money
    {
        DAL.D_Money d_money = new DAL.D_Money();
        Model.Money model = new Model.Money();

        /// <summary>
        ///表中添加一条数据
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool AddMoney(Model.ApplyInfo applyInfo, int status)
        {
            //获取该用户应该的津贴标准
            DAL.D_MoneyStandard d_moneyStandard = new DAL.D_MoneyStandard();
            model.MID = d_moneyStandard.GetStandard(applyInfo.Age);
            model.UID = applyInfo.UID;
            model.Status = status;
            return d_money.Add(model);
        }
        /// <summary>
        /// 更新Card表状态
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(int UID, int status)
        {
            return d_money.updateStatus(UID, status);
        }

        /// <summary>
        /// 获取老年津贴审核信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public Model.Money GetMoney(int UID)
        {
           return d_money.GetModel(UID);
        }

        public bool updateReason(String reason,int selectID,int adminID,int status)
        {
            Model.Money money = new Model.Money();
            money.Reason = reason;
            money.UID=selectID;
            money.Status = status;
            money.ANumber2 = adminID;
            return d_money.update(money);
        }
        public bool updateReasonSHE(String reason, int selectID, int adminID, int status)
        {
            Model.Money money = new Model.Money();
            money.Reason = reason;
            money.Id = selectID;
            money.Status = status;
            money.ANumber1 = adminID;
            return d_money.update2(money);
        }

    }
}