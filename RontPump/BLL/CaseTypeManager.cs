using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;

namespace BLL
{
    public class CaseTypeManager
    {

        CaseTypeService ctService = new CaseTypeService();

        public IList<CaseType> GetAllCaseTypes()
        {
            return ctService.GetAllCaseTypes();
        }
        public CaseType GetCaseTypeByID(int id)
        {
            return ctService.GetCaseTypeByID(id);
        }
        public List<CaseType> GetCaseTypeListbyadmin()
        {
            return ctService.GetCaseTypeListbyadmin();
        }
        public List<CaseType> GetModulesclassListbyadmin(int id)
        {
            return ctService.GetModulesclassListbyadmin(id);
        }

        public IList<CaseType> GetCaseType()
        {
            return ctService.GetCaseType();
        }
        public IList<CaseType> GetCaseType(int modelID)
        {
            return ctService.GetCaseType(modelID);
        }
        public bool DeleteCaseTypeByID(int id)
        {
            return ctService.DeleteCaseTypeByID(id);
        }
        public bool DeleteCaseTypeByIDs(string ids)
        {
            return ctService.DeleteCaseTypeByIDs(ids);
        }
        public bool AddCaseType(CaseType ct)
        {
            return ctService.AddCaseType(ct);
        }
        public bool UpdateCaseType(CaseType ct)
        {
            return ctService.UpdateCaseType(ct);
        }
        public IList<CaseType> GetCaseType(string strWhere)
        {
            return ctService.GetCaseType(strWhere);
        }
    }
}
