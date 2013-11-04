using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;

namespace BLL
{
    public class CaseManager
    {
        CaseService csServive = new CaseService();

        public bool AddCase(Cases _c)
        {
            return csServive.AddCase(_c);
        }

        public Cases GetCaseByID(int id)
        {
            return csServive.GetCaseByID(id);
        }

        public IList<Cases> GetCaseListByStrWhere(string strWhere)
        {
            return csServive.GetCaseListByStrWhere(strWhere);
        }

        public IList<Cases> GetCaseListByStrWhere(int _topN, string strWhere)
        {
            return csServive.GetCaseListByStrWhere(_topN, strWhere);
        }
        public int DeleteCasesByIDS(string IDS)
        {
            return csServive.DeleteCasesByIDS(IDS);
        }
        public bool UpdateCasesById(Cases _info)
        {
            return csServive.UpdateCasesById(_info);
        }
        public bool UpdateQxIsTopByID(int _id)
        {
            return csServive.UpdateQxIsTopByID(_id);
        }
        public bool UpdateSZIsTopByID(int _id)
        {
            return csServive.UpdateSZIsTopByID(_id);
        }

        public IList<Cases> GetPagedProducts(string tblName, string fldName, int pageSize, int currentPageIndex, string fldSort, bool sort, string strWhere, out int pageCount, out int counts)
        {
            return csServive.GetPagedProducts(tblName, fldName, pageSize, currentPageIndex, fldSort, sort, strWhere,out pageCount,out counts);
        }
        public List<Cases> GetCasesListById_top10()
        {
            return csServive.GetCasesListById_top10();
        }
    }
}
