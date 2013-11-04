using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseComm
{
    public static class StingUinity
    {
        //如果字符串长于设置的，用“...”代替
        public static string InputText(string inputString, int maxLength)
        {
            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();
                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength) + "...";
            }
            return inputString;

        }
        public static string CutString(string inputString, int maxLength)
        {
            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();
                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength);
            }
            return inputString;
        }
    }
}
