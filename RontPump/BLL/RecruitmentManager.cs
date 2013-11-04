using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using System.IO;

namespace BLL
{
   public class RecruitmentManager
    {
       RecruitmentService RS = new RecruitmentService();
       public List<Models.Recruitment> GetRecruitmentList()
       {
           return RS.GetRecruitmentList();
       }
       public bool UpdateRecruitment(Recruitment info)
       {
           return RS.UpdateRecruitment(info);
       }
       public Recruitment GetRecruitment()
       {
           return RS.GetRecruitment();
       }
    }
}
