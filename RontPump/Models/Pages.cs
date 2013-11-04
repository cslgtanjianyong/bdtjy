using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Pages
    {
        private int pageIndex;

        public int PageIndex
        {
            get
            {
                if (pageIndex <= 0)
                {
                    return 1;
                }
                return pageIndex;
            }
            set { pageIndex = value; }
        }
        public int PagesSize { get; set; }
        public string types { get; set; }
        private string tiaojian;

        public string Tiaojian
        {
            get
            {
                if (string.IsNullOrEmpty(tiaojian))
                {
                    return "";
                }
                return tiaojian;
            }
            set { tiaojian = value; }
        }
        public int id { get; set; }
    }
}
