using System;
using System.Collections.Generic;
using System.Text;

namespace BDZG.Control
{
    public static class jsOnClient
    {
        public static string Alert(string msg)
        {
            return "<script type='text/javascript'>function alert_timeout(){alert('" + EncodeJsString(msg) + "');} setTimeout('alert_timeout();',0);</script>";
        }
        public static string Alertx(string msg)
        {
            return "function alert_timeout(){alert('" + EncodeJsString(msg) + "');} setTimeout('alert_timeout();',0);";
        }
        public static string ResponseJS(string jstext)
        {
            return "<script type='text/javascript'>function alert_timeout(){" + jstext + ";} setTimeout('alert_timeout();',0);</script>";
        }
        public static string ResonseJsText(string jstext)
        {
            return "<script type='text/javascript'>" + jstext + "</script>";
        }
        public static string EncodeJsString(string str)
        {
            return str.Replace("\\", "\\\\").Replace("\'", "\\\'").Replace("\r", "\\r").Replace("\n", "\\n");
        }

        public static string ReplaceBadChar(string p_StringName)
        {
            //如果字符串为NULLor空则返回空字符串
            if (string.IsNullOrEmpty(p_StringName))
                return "";
            string _StringBadChar, _TempChar;
            string[] _ArraryBadChar;
            _StringBadChar = "@,*,#,$,!,+,',=,--,%,^,&,?,(,), <,>,[,],{,},/,\\,;,:,\",\"\"";
            _ArraryBadChar = _StringBadChar.Split(',');
            _TempChar = p_StringName;
            for (int i = 0; i < _ArraryBadChar.Length; i++)
            {
                if (_ArraryBadChar[i].Length > 0)
                    _TempChar = _TempChar.Replace(_ArraryBadChar[i], "");
            }
            return _TempChar;
        }


    }
}