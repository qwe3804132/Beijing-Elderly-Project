using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 卢沟桥项目.BLL
{
    public class B_ApplyInfo
    {
        DAL.D_ApplyInfo d_apply = new DAL.D_ApplyInfo();
        /// <summary>
        /// 写入申请信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool WriteInfo(Model.ApplyInfo model)
        {
           return d_apply.Add(model);
        }

        /// <summary>
        ///更新申请信息 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateInfo(Model.ApplyInfo model)
        {
            model.Id = d_apply.GetModel("UID="+model.UID+" and Types="+model.Types).Id;
            return d_apply.Update(model);
        }
        /// <summary>
        /// 判断是否可以申请
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="UTypes"></param>
        /// <param name="tishi"></param>
        /// <returns></returns>
        public bool CanApply(int UID, int UTypes,out string tishi)
        {
            Model.ApplyInfo model = new Model.ApplyInfo();
            if (!d_apply.Exists("UID=" + UID +" and Types=" + UTypes))//如果不存在该用户的申请信息
            {
                tishi = "apply";
                return true;
            }
            else//存在该用户申请信息 
            { 
                //判断申请状态
               model = d_apply.GetModel("UID=" + UID + " and Types=" + UTypes);
               if (UTypes == 0)//优待卡
               {
                   DAL.D_Card d_card = new DAL.D_Card();
                   Model.Card card = d_card.GetModel("UID=" + UID);
                   if (card != null)
                   {
                       return CanReapply(card.Status, out tishi);
                   }
                   else
                   {
                       tishi = "判断是否可以重新申请时出错";
                       return false;
                   }
               }
               else if (UTypes == 1)//老年津贴
               {
                   DAL.D_Money d_money = new DAL.D_Money();
                   Model.Money money = d_money.GetModel("UID=" + UID);
                   return CanReapply(money.Status, out tishi);
               }
               else
               {
                   tishi = "错误";
                   return false;
               }
            }
        }
        /// <summary>
        /// 判断是否可以重新申请
        /// </summary>
        /// <param name="status"></param>
        /// <param name="tishi"></param>
        /// <returns></returns>
        private static bool CanReapply(int status, out string tishi)
        {
            tishi = "";
            switch (status)
            {
                case 0:
                case 2:
                case 4:
                    //该状态下可以重新申请
                    break;
                case 1:
                    tishi = "正在等待二级审核，不可以重新申请";
                    break;
                case 3:
                    tishi = "正在等待三级审核，不可以重新申请";
                    break;
            }
            if (tishi == "")
            {
                tishi = "reapply";
                return true;
            }
            else
            {
                return false;
            }
        }
        public Model.ApplyInfo getInfo(int ID,int kind)
        {
            DAL.D_ApplyInfo d_apply = new DAL.D_ApplyInfo();
            return d_apply.userInfo(ID, kind);

        }
    }
}