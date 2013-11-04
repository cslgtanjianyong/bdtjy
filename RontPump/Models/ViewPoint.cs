using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{   
    [Serializable]
    public class ViewPoint
    {
        public int ID { get; set; }
        private string _Title;
        public string Title
        {
            get {
                if (string.IsNullOrEmpty(_Title))
                {
                    _Title = "-";
                }
                return _Title; 
            }
            set { _Title = value; }
        }

        public string Article { get; set; }
        public int TpId { get; set; }
        public int Istop { get; set; }
        public DateTime AddTime { get; set; }
        public string CShortDes { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public string vtag { get; set; }
    }
    public class ViewPointExtend:ViewPoint
    {
        public string TypeName { get; set; }
        public string Tag { get; set; }
    }
}
