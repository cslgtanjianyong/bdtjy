using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.IO;

namespace Com.BDZG.Web
{
    public class PageData : System.Web.UI.Page
    {
        public PageData()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //#region  Base64加密，解密方法


        ///// <summary>
        ///// Base64加密，解密方法


        ///// </summary>
        ///// <param name="s">输入字符串</param>
        ///// <param name="c">true-加密,false-解密</param>
        //public static string base64(string s, bool c)
        //{
        //    string outString = s;
        //    try
        //    {
        //        if (c)
        //        {
        //            outString = System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s));
        //        }
        //        else
        //        {
        //            outString = System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(s));
        //        }
        //    }
        //    catch { }
        //    return outString;
        //}
        //#endregion

        #region MD5加密密码
        public static string GetMD5PassWord(string pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        }
        #endregion

        /// <summary>
        /// 检查附件上传的格式
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool CheckAttach(string strExtension)
        {
            bool PicOK = false;
            string[] Extensions = ConfigurationManager.AppSettings["attach_format"].ToString().Split('|');
            for (int i = 0; i < Extensions.Length; i++)
            {
                if (strExtension == Extensions[i])
                {
                    PicOK = true; break;
                }
            }
            return PicOK;
        }

        /// <summary>
        /// 检查图片上传的格式
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool CheckPic(string strExtension)
        {
            bool PicOK = false;
            string[] Extensions = ConfigurationManager.AppSettings["pic_format"].ToString().Split('|');
            for (int i = 0; i < Extensions.Length; i++)
            {
                if (strExtension == Extensions[i])
                {
                    PicOK = true; break;
                }
            }
            return PicOK;
        }
        public static void createDir(string path)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string GetOutterPath(string InnerPath)
        {
            string GetedPath = InnerPath.Replace(GetWebRootPath(), "");
            string retPath = GetedPath.Replace("\\", "/");
            if (!retPath.StartsWith("/"))
            {
                retPath = "/" + retPath;
            }
            return retPath;
        }

        /// <summary>
        /// 获取网站的当前临时目录路径


        /// </summary>
        /// <returns></returns>
        public static string GetTempPathcn()
        {
            //完整的临时目录路径


            string fullTempPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["TempPath"]);
            if (fullTempPath[fullTempPath.Length - 1].ToString() != "\\")
            {
                fullTempPath = fullTempPath + "\\";
            }
            if (!Directory.Exists(fullTempPath))
            {
                Directory.CreateDirectory(fullTempPath);
            }
            string currentTempDir = "classnavigation";
            //string currentTempDir = System.DateTime.Now.ToString("yyyyMMdd");
            string currentFullTempDir = fullTempPath + currentTempDir + "\\";
            //以当前日期作为名称创建子目录,作为当前临时目录
            if (!Directory.Exists(currentFullTempDir))
            {
                Directory.CreateDirectory(currentFullTempDir);
            }

            ////只保留昨天和今天的临时目录,其他临时目录全部删除
            //DirectoryInfo[] subTempDirs = new DirectoryInfo(fullTempPath).GetDirectories();
            //if (subTempDirs.Length > 2)
            //{
            //    string yesterdayTempDir = System.DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            //    foreach (DirectoryInfo dir in subTempDirs)
            //    {
            //        if (dir.Name != currentTempDir && dir.Name != yesterdayTempDir)
            //        {
            //            dir.Delete(true);
            //        }
            //    }
            //}
            //产生的临时目录将被垃圾清理服务删除


            return currentFullTempDir;
        }



        public static string GetTempPath()
        {
            //完整的临时目录路径


            string fullTempPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["TempPath"]);
            if (fullTempPath[fullTempPath.Length - 1].ToString() != "\\")
            {
                fullTempPath = fullTempPath + "\\";
            }
            if (!Directory.Exists(fullTempPath))
            {
                Directory.CreateDirectory(fullTempPath);
            }
            string currentTempDir = System.DateTime.Now.ToString("yyyyMMdd");
            string currentFullTempDir = fullTempPath + currentTempDir + "\\";
            //以当前日期作为名称创建子目录,作为当前临时目录
            if (!Directory.Exists(currentFullTempDir))
            {
                Directory.CreateDirectory(currentFullTempDir);
            }

            ////只保留昨天和今天的临时目录,其他临时目录全部删除
            //DirectoryInfo[] subTempDirs = new DirectoryInfo(fullTempPath).GetDirectories();
            //if (subTempDirs.Length > 2)
            //{
            //    string yesterdayTempDir = System.DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            //    foreach (DirectoryInfo dir in subTempDirs)
            //    {
            //        if (dir.Name != currentTempDir && dir.Name != yesterdayTempDir)
            //        {
            //            dir.Delete(true);
            //        }
            //    }
            //}
            //产生的临时目录将被垃圾清理服务删除


            return currentFullTempDir;
        }
        /// <summary>
        /// 获取网站根目录的绝对路径
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetWebRootPath()
        {
            return HttpContext.Current.Server.MapPath("~/");
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
        //通过refno获取课题ClassCategoryID


    }
}