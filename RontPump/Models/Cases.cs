using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Cases
    {
        public Cases()
        {
            CaseType = new CaseType();
        }

        public int ID { get; set; }

        public CaseType CaseType { get; set; }

        public string CTID { get; set; }

        public string CName { get; set; }

        public string ImgSrc { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public DateTime AddTime { get; set; }
    }
}
