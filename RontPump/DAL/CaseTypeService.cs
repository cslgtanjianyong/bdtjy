using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class CaseTypeService
    {

        public IList<CaseType> GetAllCaseTypes()
        {
            IList<CaseType> list = new List<CaseType>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_GetAllCaseTypes", null, CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    CaseType ct = new CaseType();
                    ct.ID = Convert.ToInt32(dr["ID"]);
                    ct.CTName = dr["CTName"].ToString();
                    ct.ModelID = Convert.ToInt32(dr["ModelID"]);
                    list.Add(ct);
                }
                dr.Close();
            }

            return list;
        }

        #region 通过ID获取CaseType实体--zfcony
        /// <summary>
        /// 通过ID获取CaseType实体--zfcony
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public CaseType GetCaseTypeByID(int id)
        {
            CaseType csty = new CaseType();

            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("Pro_GetCaseTypebyID", para, CommandType.StoredProcedure))
            {
                if (dr.Read())
                {
                    csty.ID = Convert.ToInt32(dr["ID"]);
                    csty.ModelID = Convert.ToInt32(dr["ModelID"]);
                    csty.CTName = Convert.ToString(dr["CTName"]);
                }
                dr.Close();
            }
            return csty;
        }
        #endregion


        #region 得到所有的casetype，用dropdownlist绑定--zfcony

        /// <summary>
        ///  得到所有的casetype，用dropdownlist绑定
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<CaseType> GetCaseTypeListbyadmin()
        {
            List<CaseType> _list = null;
            DataTable _dt = SqlHelper.GetDataSet(CommandType.Text, "select * from CaseType where ModelID=0 order by [ID] asc", null).Tables[0];
            if (_dt.Rows.Count > 0)
            {
                _list = new List<CaseType>();
                foreach (DataRow _row in _dt.Rows)
                {
                    int _id = Convert.ToInt32(_row["ID"]);
                    _list.Add(GetCaseTypeByID(_id));
                }
                return _list;
            }
            else
                return _list;

        }
        #endregion

        #region 通过类型得到一级分类名

        ///// <summary>
        ///// 通过类型得到一级级分类名
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public List<CaseType> GetModulesNamebyadmin(int id)
        //{
        //    List<CaseType> _list = null;
        //    DataTable _dt = SqlHelper.GetDataSet(CommandType.Text, "select * from CaseType where ModelID=" + id + " order by [ID] asc", null).Tables[0];
        //    if (_dt.Rows.Count > 0)
        //    {
        //        _list = new List<CaseType>();
        //        foreach (DataRow _row in _dt.Rows)
        //        {
        //            int _id = Convert.ToInt32(_row["ID"]);
        //            _list.Add(GetCaseTypeByID(_id));
        //        }
        //        return _list;
        //    }
        //    else
        //        return _list;

        //}
        #region 通过类型得到二级分类信息

        /// <summary>
        /// 通过类型得到二级分类信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<CaseType> GetModulesclassListbyadmin(int id)
        {
            List<CaseType> _list = null;
            DataTable _dt = SqlHelper.GetDataSet(CommandType.Text, "select * from CaseType where ModelID=" + id + " order by [ID] asc", null).Tables[0];
            if (_dt.Rows.Count > 0)
            {
                _list = new List<CaseType>();
                foreach (DataRow _row in _dt.Rows)
                {
                    int _id = Convert.ToInt32(_row["ID"]);
                    _list.Add(GetCaseTypeByID(_id));
                }
                return _list;
            }
            else
                return _list;

        }


        #endregion

        #endregion

        public IList<CaseType> GetCaseType()
        {
            IList<CaseType> list = null;

            //proc_CaseType_GetList
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_CaseType_GetList", null, CommandType.StoredProcedure))
            {
                if (dr.HasRows)
                {
                    list = new List<CaseType>();
                    while (dr.Read())
                    {
                        CaseType ct = new CaseType();
                        ct.ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]);
                        ct.CTName = Convert.IsDBNull(dr["CTName"]) ? "" : dr["CTName"].ToString();
                        ct.ModelID = Convert.IsDBNull(dr["ModelID"]) ? 0 : Convert.ToInt32(dr["ModelID"]);
                        list.Add(ct);
                    }
                }
                dr.Close();
            }

            return list;
        }

        public IList<CaseType> GetCaseType(int modelID)
        {
            IList<CaseType> list = null;
            SqlParameter[] para = { 
                                    new SqlParameter("@ModelID",modelID)
                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_CaseType_GetByModelID", para, CommandType.StoredProcedure))
            {
                if (dr.HasRows)
                {
                    list = new List<CaseType>();
                    while (dr.Read())
                    {
                        CaseType ct = new CaseType();
                        ct.ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]);
                        ct.CTName = Convert.IsDBNull(dr["CTName"]) ? "" : dr["CTName"].ToString();
                        ct.ModelID = Convert.IsDBNull(dr["ModelID"]) ? 0 : Convert.ToInt32(dr["ModelID"]);
                        list.Add(ct);
                    }
                }
            }
            return list;
        }


        public bool DeleteCaseTypeByID(int id)
        {
            bool flag = false;

            SqlParameter[] para = { 
                                    new SqlParameter("@ID",id)
                                  };
            flag = SqlHelper.ExecuteNonQuery("proc_CaseType_DeleteByID", para, CommandType.StoredProcedure) > 0 ? true : false;

            return flag;
        }
        public bool DeleteCaseTypeByIDs(string ids)
        {
            bool flag = false;

            SqlParameter[] para = { 
                                    new SqlParameter("@IDS",ids)
                                  };
            flag = SqlHelper.ExecuteNonQuery("proc_CaseType_DeleteByIDs", para, CommandType.StoredProcedure) > 0 ? true : false;
            return flag;
        }

        public bool AddCaseType(CaseType ct)
        {
            bool flag = false;

            SqlParameter[] paras = { 
                                    new SqlParameter("@CTName",ct.CTName),
                                    new SqlParameter("@ModelID",ct.ModelID)
                                   };
            flag = SqlHelper.ExecuteNonQuery("proc_CaseType_Add", paras, CommandType.StoredProcedure) > 0 ? true : false;
            return flag;
        }
        public bool UpdateCaseType(CaseType ct)
        {
            bool flag = false;

            SqlParameter[] paras = { 
                                    new SqlParameter("@CTName",ct.CTName),
                                    new SqlParameter("@ModelID",ct.ModelID),
                                    new SqlParameter("@ID",ct.ID)
                                   };

            flag = SqlHelper.ExecuteNonQuery("proc_CaseType_Update", paras, CommandType.StoredProcedure) > 0 ? true : false;

            return flag;
        }

        public IList<CaseType> GetCaseType(string strWhere)
        {
            IList<CaseType> list = null;
            SqlParameter[] para = { 
                                    new SqlParameter("@StrWhere",strWhere)
                                  };
            using (SqlDataReader dr = SqlHelper.ExecuteReader("proc_CaseType_GetByWhere", para, CommandType.StoredProcedure))
            {
                if (dr.HasRows)
                {
                    list = new List<CaseType>();
                    while (dr.Read())
                    {
                        CaseType ct = new CaseType();
                        ct.ID = Convert.IsDBNull(dr["ID"]) ? 0 : Convert.ToInt32(dr["ID"]);
                        ct.CTName = Convert.IsDBNull(dr["CTName"]) ? "" : dr["CTName"].ToString();
                        ct.ModelID = Convert.IsDBNull(dr["ModelID"]) ? 0 : Convert.ToInt32(dr["ModelID"]);
                        list.Add(ct);
                    }
                }
                
            }
            return list;
        }
    }
}
