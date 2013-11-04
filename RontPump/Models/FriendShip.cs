using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace Models
{
    [Serializable]
    public  class FriendShip
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

        private string _Fword;
        /// <summary>
        /// 
        /// </summary>
        public string Fword
        {
            get
            {
                return _Fword;
            }
            set
            {
                _Fword=value;
            }
        }

        private string _FUrl;
        /// <summary>
        /// 
        /// </summary>
        public string FUrl
        {
            get
            {
                return _FUrl;
            }
            set
            {
                _FUrl=value;
            }
        }

        private string _FPerson;
        /// <summary>
        /// 
        /// </summary>
        public string FPerson
        {
            get
            {
                return _FPerson;
            }
            set
            {
                _FPerson=value;
            }
        }

        private string _FEmail;
        /// <summary>
        /// 
        /// </summary>
        public string FEmail
        {
            get
            {
                return _FEmail;
            }
            set
            {
                _FEmail=value;
            }
        }

        private string _FQQMsn;
        /// <summary>
        /// 
        /// </summary>
        public string FQQMsn
        {
            get
            {
                return _FQQMsn;
            }
            set
            {
                _FQQMsn=value;
            }
        }

        private string _FTel;
        /// <summary>
        /// 
        /// </summary>
        public string FTel
        {
            get
            {
                return _FTel;
            }
            set
            {
                _FTel=value;
            }
        }

        private DateTime _AddTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            get
            {
                return _AddTime;
            }
            set
            {
                _AddTime=value;
            }
        }
        private int _TpId;

        public int TpId
        {
            get { return _TpId; }
            set { _TpId = value; }
        }
        

    }
}

