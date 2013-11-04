using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;
using BDZG.Control;
using Ajax;

namespace zhongSen.admin.CaseNewsBMS
{
    public partial class case_type_list : System.Web.UI.Page
    {
        CaseTypeManager ctManager = new CaseTypeManager();

        public static IList<CaseType> list = null;
        public static IList<CaseType> list2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utility.RegisterTypeForAjax(typeof(case_type_list));

                InitCaseTypes();
            }
        }

        void InitCaseTypes()
        {
            list = ctManager.GetCaseType(0);
        }

        public IList<CaseType> InitLvSCaseType(int mid)
        {
            list2 = ctManager.GetCaseType(mid);
            return list2;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxMethod]
        public bool DeleteCaseType(int id)
        {
            bool flag = false;
            string ids = string.Empty;
            CaseType ct = ctManager.GetCaseTypeByID(id);

            ids = id.ToString();

            if (ct.ModelID == 0)
            {
                IList<CaseType> list = ctManager.GetCaseType(id);
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i < list.Count - 1)
                        {
                            ids += ","+list[i].ID + ",";
                        }
                        else
                        {
                            ids += ","+list[i].ID;
                        }
                    }
                }
            }
            flag = ctManager.DeleteCaseTypeByIDs(ids);
            return flag;
        }

        [AjaxMethod]
        public bool AddCaseType(string ctname, string mid)
        {
            bool flag = false;

            CaseType ct = new CaseType();
            ct.CTName = ctname;
            ct.ModelID = Convert.ToInt32(mid);
            flag = ctManager.AddCaseType(ct);
            return flag;
        }

        [AjaxMethod]
        public bool UpdateCaseType(string id, string ctname)
        {
            bool flag = false;

            CaseType ct = ctManager.GetCaseTypeByID(Convert.ToInt32(id));
            ct.CTName = ctname;

            flag = ctManager.UpdateCaseType(ct);

            return flag;
        }


    }
}