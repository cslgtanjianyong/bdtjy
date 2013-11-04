using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using Models;
using BLL;

namespace EnterpriseComm
{
    public class BaseTools
    {
        #region "读取数据库联接字符串"
        public static string GetDbConnectionString()
        {
            string connectionString = string.Empty;

            #region "config"
            XmlDocument _xml = new XmlDocument();
            _xml.Load(HttpContext.Current.Server.MapPath(VirtualPathUtility.ToAbsolute("~").TrimEnd('/') + "/Configs/DB.config"));

            XmlNodeReader oXmlReader = new XmlNodeReader(_xml);
            while (oXmlReader.Read())
            {
                if (oXmlReader.NodeType != XmlNodeType.Element) continue;
                //若是数据库映射Node
                if (oXmlReader.Name.ToLower() == "database")
                {
                    //根据数据库结点,生成一个Database对象
                    if (oXmlReader.GetAttribute("mapname").Equals("System"))
                    {
                        int i = oXmlReader.Depth;
                        string node, nodeValue;
                        while (oXmlReader.Read() && oXmlReader.Depth > i)
                        {
                            if ((oXmlReader.NodeType == XmlNodeType.Element) && (oXmlReader.Name == "parameter"))
                            {
                                node = oXmlReader.GetAttribute("name");
                                nodeValue = oXmlReader.GetAttribute("value");
                                if ((node != null) && (nodeValue != null))
                                {
                                    if (node.Equals("Data Source"))
                                    {
                                        connectionString += node + "=" + nodeValue + ";";
                                    }
                                    if (node.Equals("User ID"))
                                    {
                                        connectionString += node + "=" + nodeValue + ";";
                                    }
                                    if (node.Equals("Password"))
                                    {
                                        connectionString += node + "=" + nodeValue + ";";
                                    }
                                    if (node.Equals("Initial Catalog"))
                                    {
                                        connectionString += node + "=" + nodeValue + ";";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region "XML数据库配置"
            //HttpContext context = HttpContext.Current;
            //string DBPath = context.Server.MapPath("~/Configs/DB.xml");

            //string datasource = string.Empty;
            //string dbName = string.Empty;
            //string UserIDs = string.Empty;
            //string pwd = string.Empty;

            //XmlDocument doc = new XmlDocument();
            //doc.Load(DBPath);
            //  //根节点
            // XmlNode rootNode = doc.DocumentElement;
            // //判断是否是xml元素
            // if (rootNode is XmlElement)
            // {
            //     //循环item的子节点
            //     foreach (XmlNode CChildNode in rootNode.ChildNodes)
            //     {
            //         if (CChildNode.Name == "DBName")
            //         {
            //             dbName = CChildNode.InnerText;
            //         }
            //         if (CChildNode.Name == "DataSource")
            //         {
            //             datasource = CChildNode.InnerText;
            //         }

            //         if (CChildNode.Name == "UserID")
            //         {

            //             UserIDs = CChildNode.InnerText;

            //         }
            //         if (CChildNode.Name == "PWD")
            //         {

            //             pwd = CChildNode.InnerText;

            //         }

            //     }
            // }

            // string connections = "Data Source="+datasource+";Initial Catalog="+dbName+";User ID="+UserIDs+";Pwd="+pwd;
            //return connections;
            #endregion

            return connectionString;
        }
        #endregion

        #region "去除字符串中的重复字串"
        /// <summary>
        /// 去除字符串中的重复字串
        /// </summary>
        /// <param name="strSource">源字符串 如 124,123,123,456</param>
        /// <param name="strFlag">为源字符串中的分隔符 如 ,</param>
        /// <returns>返回结果 124,123,456</returns>
        public static string DelRepeat(string strSource, char strFlag)
        {
            string strouput = "";
            Array stringArray = strSource.Split(new char[] { strFlag });
            List<string> listString = new List<string>();
            //遍历删除重复项 
            foreach (string eachString in stringArray)
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }
            //遍历输出 
            foreach (string string1 in listString)   //测试值 
            {
                strouput = strouput + string1 + strFlag;
            }
            strouput = strouput.Substring(0, strouput.Length - 1);
            return strouput;



        }

        #endregion

        #region 加密 MD5 SHA256
        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }
        #endregion

        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] tmp = { strContent };
                return tmp;
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int p_3)
        {
            string[] result = new string[p_3];

            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < p_3; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }
        #endregion

        #region "是否为ip"
        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");

        }
        #endregion

        #region 读写COOKIE
        /// <summary>
        /// 获取单个cookie值
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            return cookie.Value;
        }
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteSingleCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);

        }
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);

        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetSingleCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }
        #endregion

        #region "email格式"
        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region 字符串截取("需要截取字符","截取长度")
        public static string stringformat(string str, int n)
        {
            ///
            ///格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
            ///
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return str;
            }
            else
            {
                int t = 0;
                char[] q = str.ToCharArray();
                for (int i = 0; i < q.Length; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t += 1;
                    }
                    if (t >= n)
                    {
                        break;
                    }
                }
                return (temp+"...");
            }
        }
        #endregion

        #region 判断上传文件格式(返回相应的格式)
        public static string CheckTextFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            string fileType = string.Empty; ;
            try
            {
                byte data = br.ReadByte();
                fileType += data.ToString();
                data = br.ReadByte();
                fileType += data.ToString();
                switch (fileType)
                {
                    case "7173":
                        fileType = "gif";
                        break;
                    case "255216":
                        fileType = "jpg";
                        break;
                    case "13780":
                        fileType = "png";
                        break;
                    case "6677":
                        fileType = "bmp";
                        break;
                    case "6787":
                        fileType = "swf";
                        break;
                    default:
                        fileType = "9999999";
                        break;
                }
                return fileType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    br.Close();
                }
            }
        }
        //常见字符编码

        // 255216 jpg;   // 7173 gif;  // 6677 bmp,   // 13780 png;   // 6787 swf  // 7790 exe dll, // 8297 rar   // 8075 zip  
        // 55122 7z   // 6063 xml   // 6033 html   // 239187 aspx  // 117115 cs   // 119105 js   // 102100 txt   // 255254 sql   
        #endregion

        #region 获取两个时间比值
        /// 已重载.计算两个日期的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString() + "天"
                        + ts.Hours.ToString() + "小时"
                        + ts.Minutes.ToString() + "分钟"
                        + ts.Seconds.ToString() + "秒";
            }
            catch
            {

            }
            return dateDiff;
        }
        #endregion

        #region 获取友情链接
        public string outputfriendship()
        {
            FriendShipManager _friendship = new FriendShipManager();
            List<FriendShip> lstfriendship = _friendship.GetLinkList_all();
            StringBuilder _str = new StringBuilder();
            if (lstfriendship != null && lstfriendship.Count > 0)
            {
                for (int i = 0; i < lstfriendship.Count; i++)
                {
                    _str.Append("\n\t\t<div class='fdship'><a target='_blank' href='" + lstfriendship[i].FUrl + " '>" + lstfriendship[i].Fword + "</a></div>");
                }
                _str.Append("\n\t</ul>");
            }
            else
            {
                return "";
            }
            return _str.ToString();
        }
        #endregion
    }
}
