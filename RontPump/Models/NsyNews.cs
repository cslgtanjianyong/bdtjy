using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{   
    [Serializable]
    public class NsyNews
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public DateTime AddTime { get; set; }
        public string Title { get; set; }
    }
}
