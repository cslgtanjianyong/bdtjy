using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PointTypeService
    {
        /// <summary>
        /// 获取观点列表
        /// </summary>
        /// <returns></returns>
        public List<PointType> GetPointTypeList()
        {
            List<PointType> list = new List<PointType>();
            string sql = "select ID,TypeName from PointType";
            DataSet ds = DbHelper.GetDataSetBySql(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PointType pt = new PointType();
                pt.ID = Convert.ToInt32(dr["ID"]);
                pt.TypeName = dr["TypeName"].ToString();
                list.Add(pt);
            }
            return list;
        }
        /// <summary>
        /// 根据id获取TypeName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetViewPointTpName(int id)
        {
            string sql = "select TypeName from PointType where id=@id";
            SqlParameter[] para = {
                                      new SqlParameter("@id",id)
                                  };
            string tpName = DbHelper.ExecuteScalarBySql(sql, para).ToString();
            return tpName;
        }

        public PointType GetPointType(int id)
        {
            PointType pt = null;
            //proc_PointType_GetByID
            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };

            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_PointType_GetByID", para, CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    pt = new PointType();
                    pt.ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]);
                    pt.TypeName = Convert.IsDBNull(dr["TypeName"]) ? "" : dr["TypeName"].ToString();
                    pt.Tag = Convert.IsDBNull(dr["tag"]) ? "" : dr["tag"].ToString();

                } dr.Close();
            }

            return pt;
        }

    }
}
