using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RecruitmentService
    {
        //查询
        public List<Recruitment> GetRecruitmentList()
        {
            List<Recruitment> list = new List<Recruitment>();
            string sql = "pro_Get_Recruitment";
            SqlParameter[] para ={};
            DataSet ds = DbHelper.GetDataSetByProc(sql, para);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Recruitment _info = new Recruitment();
                _info.ID = Convert.ToInt32(dr["ID"]);
                _info.rcontents = dr["rcontents"].ToString();
                list.Add(_info);
            }
            return list;
        }
        //修改
        public bool UpdateRecruitment(Recruitment info)
        {
            string sql = "pro_UpdateRecruitment";
            SqlParameter[] para = {
                                      new SqlParameter("@rcontents",info.rcontents)
                                  };
            if (DbHelper.ExecuteCommandByProc(sql, para) > 0)
            {
                return true;
            }
            return false;
        }

        public Recruitment GetRecruitment()
        {
            Recruitment rt = new Recruitment();

            using (SqlDataReader dr = SqlHelper.ExecuteReader("sw_GetRecruitments",null,CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    rt.rcontents = dr["rcontents"].ToString();
                }
                dr.Close();
            }

            return rt;
        }
    }
}
