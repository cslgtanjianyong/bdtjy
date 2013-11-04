using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class BoCaseTypeManager
    {
        BoCaseTypeService CaseSv = new BoCaseTypeService();
        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="tpName"></param>
        /// <returns></returns>
        public bool AddCaseType(string tpName)
        {
            return CaseSv.AddCaseType(tpName);
        }
        /// <summary>
        /// 获取案例分类列表
        /// </summary>
        /// <returns></returns>
        public List<BoCaseType> GetBoCaseType()
        {
            return CaseSv.GetBoCaseType();
        }
    }
}
