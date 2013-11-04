using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace Models
{
    [Serializable]
    public  class LinkType
    {

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id=value;
            }
        }

        private string _LinkName;
        /// <summary>
        /// 
        /// </summary>
        public string LinkName
        {
            get
            {
                return _LinkName;
            }
            set
            {
                _LinkName=value;
            }
        }

    }
}

