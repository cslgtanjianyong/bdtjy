using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class PointType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public string Tag { get; set; }
    }
}
