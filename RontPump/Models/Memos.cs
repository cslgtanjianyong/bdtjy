using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public  class Memos
    {

        private int _ID;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID=value;
            }
        }

        private string _UserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName=value;
            }
        }

        private string _TelPhone;
        /// <summary>
        /// 
        /// </summary>
        public string TelPhone
        {
            get
            {
                return _TelPhone;
            }
            set
            {
                _TelPhone=value;
            }
        }

        private string _Email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email=value;
            }
        }

        private string _CopAddress;
        /// <summary>
        /// 
        /// </summary>
        public string CopAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_CopAddress))
                {
                    _CopAddress = "-";
                }
                return _CopAddress;
            }
            set
            {
                _CopAddress=value;
            }
        }

        private string _Cop;
        /// <summary>
        /// 
        /// </summary>
        public string Cop
        {
            get
            {
                if (string.IsNullOrEmpty(_Cop))
                {
                    _Cop = "-";
                }
                return _Cop;
            }
            set
            {
                _Cop=value;
            }
        }

        private string _MemosContent;
        /// <summary>
        /// 
        /// </summary>
        public string MemosContent
        {
            get
            {
                return _MemosContent;
            }
            set
            {
                _MemosContent=value;
            }
        }
        private string _Zhiwei;

        public string Zhiwei
        {
            get { return _Zhiwei; }
            set { _Zhiwei = value; }
        }
        private string _SubTime;

        public string SubTime
        {
            get { return _SubTime; }
            set { _SubTime = value; }
        }
        private string _BrandName;

        public string BrandName
        {
            get 
            {
                if (string.IsNullOrEmpty(_BrandName))
                {
                    _BrandName = "-";
                }
                return _BrandName; 
            }
            set { _BrandName = value; }
        }

        private string _BrandWeb;

        public string BrandWeb
        {
            get
            {
                if (string.IsNullOrEmpty(_BrandWeb))
                {
                    _BrandWeb = "-";
                }
                return _BrandWeb;
            }
            set { _BrandWeb = value; }
        }
        private string _Pkobj;

        public string Pkobj
        {
            get
            {
                if (string.IsNullOrEmpty(_Pkobj))
                {
                    _Pkobj = "-";
                }
                return _Pkobj;
            }
            set { _Pkobj = value; }
        }
        private string _Hanye;

        public string Hanye
        {
            get
            {
                if (string.IsNullOrEmpty(_Hanye))
                {
                    _Hanye = "-";
                }
                return _Hanye;
            }
            set { _Hanye = value; }
        }
    }
}

