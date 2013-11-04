using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Models;

namespace EnterpriseComm
{
    public class CurrentUser
    {

        private const string ACCOUNT_KEY = "ACCOUNT_KEY";

        public CurrentUser()
        { }

        public static UserInfo GetUserInfo
        {
            get
            {
                if (HttpContext.Current.Session[ACCOUNT_KEY] == null)
                {
                    return null;
                }
                return (UserInfo)HttpContext.Current.Session[ACCOUNT_KEY];
            }
        }

        public static UserInfo SetUserInfo
        {
            set
            {
                HttpContext.Current.Session[ACCOUNT_KEY] = value;
            }
        }
    }
}
