using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class PointTypeManager
    {
        PointTypeService ptSv = new PointTypeService();
        //观点分类列表
        public List<PointType> GetPointTypeList()
        {
            return ptSv.GetPointTypeList();
        }
        /// <summary>
        /// 根据id获取TypeName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetViewPointTpName(int id)
        {
            return ptSv.GetViewPointTpName(id);
        }
        public PointType GetPointType(int id)
        {
            return ptSv.GetPointType(id);
        }
    }
}
