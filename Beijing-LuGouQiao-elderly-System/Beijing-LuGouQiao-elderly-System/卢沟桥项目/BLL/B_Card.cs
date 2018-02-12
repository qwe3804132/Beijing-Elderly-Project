using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_Card
    {
        DAL.D_Card d_card = new DAL.D_Card();
        Model.Card model = new Model.Card();

        /// <summary>
        ///表中添加一条数据
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool AddCard(int UID,int status)
        {
            model.UID = UID;
            model.Status=status;
            model.GetTimes = DateTime.Now;
            return d_card.Add(model);
        }

        public bool UpdateCard(int ID)
        {   
            model.Id = ID;
            model.Status = 3;
            return d_card.Update(model);
        }
        public bool UpdateCard_lingqu(int ID) 
        {
            return d_card.updateCardStatus(ID, 4);
        }
        public bool UpdateCard_dailingqu(int ID)
        {
            return d_card.updateCardStatus(ID,3);
        }
        public bool UpdateCard_daizhizuo(int ID)
        {
            return d_card.updateCardStatus(ID, 2);
        }
        //public bool UpdateCard_lingqu(int ID);


        //public bool UpdateStatus(int UID, int status);


        /// <summary>
        /// 获取优待卡审核信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public Model.Card GetMoney(int UID)
        {
            return d_card.GetModel(UID);
        }
        public bool UpdateStatus(int UID, int status)
        {
            model.Id = UID;
            model.CardStatus = 4;
            model.GetTimes = DateTime.Now;
            return d_card.Update(model);
        }

        public bool updateReason(String reason, int selectID, int status)
        {
            model.Id = selectID;
            model.Reason = reason;
            model.Status = status;
            model.CardStatus = 0;
            return d_card.Update(model);
        }

        public bool updateReason(String reason, int selectID, int adminID, int status)
        {
            Model.Card card = new Model.Card();
            card.Reason = reason;
            card.UID = selectID;
            card.Status = status;
            card.ANumber2 = adminID;
            card.CardStatus = 1;
            return d_card.update(card);
        }

        public bool updateReasonSHE(String reason, int selectID, int adminID, int status)
        {
            Model.Card card = new Model.Card();
            card.Reason = reason;
            card.Id = selectID;
            card.Status = status;
            card.ANumber1 = adminID;
            return d_card.update1(card);
        }


        public bool UpdateByStatusAndType(int status,int cardStatus)
        {
            return d_card.UpdateByStatusAndType(status, cardStatus);
        }


    }
}