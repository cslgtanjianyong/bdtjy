//======================================================================
// 用    途：分页方法
// 说    明：1）包含：分页功能（完整版和迷你版）+ 分页样式（完整版和迷你版） 
//              完整版和迷你版命名相互独立、互不冲突，可以同时使用。
//           2）完整版：可以限制最大页数，同时出现的最多页码数，两端的固定页码数，页数统计提示控制（出现于右端）。
//
//              [1]   [2]   [..][50][51][52(中心)][53][54][..]   [98]   [99]
//              固定页码数                                        固定页码数
//              同时出现的最多页码数：11(包括[..]) 即由中心向两边对称延伸5
//
//           3）迷你版：可以限制最大页数，页数统计提示控制（出现于左端）。
//           4）具体详细说明，请参照方法说明。
//====================================================================== 

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace zhongsen.Comm
{
    public class PageControl
    {
        public PageControl()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 分页函数(控件+样式)完整版
        /// <summary>
        /// 分页控件+分页样式合集
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagersWithCss(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title)
        {
            return GetDisplayPagersCss() + DisplayPagers(currentPage, totalRecord, perPageCount, strPage, urlLink, title);
        }

        /// <summary>
        /// 分页控件+分页样式合集
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">true:显示"共?页"|false:不显示</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagersWithCss(int currentPage, int totalRecord, int perPageCount, bool strPage, string urlLink, string title)
        {
            if (strPage)
            {
                return GetDisplayPagersCss() + DisplayPagers(currentPage, totalRecord, perPageCount, "", urlLink, title);
            }
            else
            {
                return GetDisplayPagersCss() + DisplayPagers(currentPage, totalRecord, perPageCount, " ", urlLink, title);
            }
        }

        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagers(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title)
        {
            //int maxPages = 99;//允许呈现的最大页码
            //int extendPages = 5;//以当前页码为中心,两侧允许出现的最多页码数(包含[..]和固定页码),如:[1][2][..][50][51][52(中心)][53][54][..][98][99]
            //int mustShowPages = 2;//在首尾必须显示的页码数,如:[1][2]...[]...[98][99]
            return DisplayPagers(currentPage, totalRecord, perPageCount, strPage, urlLink, title, 99, 5, 2);
        }

        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <param name="maxPages">允许呈现的最大页码</param>
        /// <param name="extendPages">以当前页码为中心,两侧允许出现的最多页码数(包含[..]和固定页码),如:[1][2][..][50][51][52(中心)][53][54][..][98][99]</param>
        /// <param name="mustShowPages">在首尾必须显示的页码数,如:[1][2]...[]...[98][99]</param>
        /// <returns></returns>
        public static string DisplayPagers(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title, int maxPages, int extendPages, int mustShowPages)
        {
            int totalPageCount = 1;//总页数

            if (totalRecord % perPageCount == 0)
            {
                totalPageCount = (totalRecord / perPageCount);
            }
            else
            {
                totalPageCount = (totalRecord / perPageCount) + 1;
            }

            //if (totalPageCount >= maxPages)//限定页数不超过maxPages(99)
            //{
            //    totalPageCount = maxPages;
            //}

            if (currentPage > totalPageCount)//如果当前页数大于总页数,调整为最后页
            {
                currentPage = totalPageCount;
            }
            if (currentPage <= 0)//如果当前页数小于等于0,调整为第一页
            {
                currentPage = 1;
            }

            //开始组合分页控件
            StringBuilder strControl = new StringBuilder();
            strControl.Append("<div class='page_link_full'>");
            if (currentPage > 1)//如果当前页不等于1则显示上一页
            {
                strControl.AppendFormat("<span class='page_up link01'><a title='上一页' href='" + urlLink + "'>上一页</a></span>", (currentPage - 1).ToString());
            }

            if (totalPageCount <= extendPages + 1)//如果总页数小于等于6则页数全部显示
            {
                for (int i = 1; i <= totalPageCount; i++)
                {
                    if (i == currentPage)
                    {
                        strControl.AppendFormat("<span class='current'>{0}</span>", i.ToString());
                    }
                    else
                    {
                        strControl.AppendFormat("<a title='{1}第{0}页'  href='" + urlLink + "'>{0}</a>", i.ToString(), title);
                    }
                }
            }
            else//如果总页数大于6
            {
                //中间页码部位
                for (int i = 0; i <= extendPages * 2; i++)//extendPages * 2(10)|mustShowPages(2)
                {
                    if (i < mustShowPages || i > extendPages * 2 - mustShowPages)//头尾页码
                    {
                        if ((i + 1 == currentPage && i < mustShowPages) || (totalPageCount - extendPages * 2 + i == currentPage && i > extendPages * 2 - mustShowPages))//当前页
                        {
                            strControl.AppendFormat("<span class='current'>{0}</span>", currentPage.ToString());
                        }
                        else if (i < mustShowPages)
                        {
                            strControl.AppendFormat("<a title='{1}第{0}页'  href='" + urlLink + "'>{0}</a>", (i + 1).ToString(), title);
                        }
                        else if (i > extendPages * 2 - mustShowPages)
                        {
                            strControl.AppendFormat("<a title='{1}第{0}页'  href='" + urlLink + "'>{0}</a>", (totalPageCount - extendPages * 2 + i).ToString(), title);
                        }
                    }
                    else if ((currentPage - extendPages + i > mustShowPages) && (currentPage - extendPages + i <= totalPageCount - mustShowPages))//中部页码
                    {
                        if (i == extendPages)//当前页
                        {
                            strControl.AppendFormat("<span class='current'>{0}</span>", currentPage.ToString());
                        }
                        else if ((i == mustShowPages && currentPage - 1 > extendPages) || (i == extendPages * 2 - mustShowPages && totalPageCount - currentPage > extendPages))//可能是[...]/[页码]的特殊位置
                        {
                            strControl.Append("<span class='dian' style='letter-spacing:normal;'>...</span>");
                        }
                        else
                        {
                            strControl.AppendFormat("<a title='{1}第{0}页'  href='" + urlLink + "'>{0}</a>", (currentPage - extendPages + i).ToString(), title);
                        }
                    }
                }
            }

            if (currentPage != totalPageCount)//如果当前页不是最后一页,则出现下一页按钮
            {
                strControl.AppendFormat("<span class='page_down link01'><a title='下一页' href='" + urlLink + "'>下一页</a></span>", (currentPage + 1).ToString());
            }

            if (string.IsNullOrEmpty(strPage))//默认为"共?页"
            {
                try
                {
                    strControl.AppendFormat("   <span class='num'>共{0}页</span>", totalPageCount);
                }
                catch
                {
                    strControl.AppendFormat("   <span class='num'>共{0}页</span>", totalPageCount);
                }
            }
            else
            {
                try
                {
                    strControl.AppendFormat(strPage, totalPageCount, currentPage, totalRecord);
                }
                catch
                {
                    strControl.AppendFormat("   <span class='num'>共{0}页</span>", totalPageCount);
                }
            }

            strControl.Append("</div>");//分页控件组合完毕

            if (totalRecord <= perPageCount)//只有一页的不显示分页控件
            {
                return "";
            }
            return strControl.ToString();
        }

        /// <summary>
        /// 分页控件样式
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayPagersCss()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style>");
            sb.Append(".page_link_full {padding:0px 0px;text-align:right;font-size:12px;float:left; width:100%; margin-left:30px; margin-top:20px;font-family:'宋体';line-height:18px;height:24px;}");
            sb.Append(".page_link_full a{border:1px #eee solid;padding:1px 5px;margin:1px 2px;color:#036CB4;text-decoration:none;float:left;height:18px;line-height:18px;}");
            sb.Append(".page_link_full a:link{color:#195CB5;text-decoration:none;border:1px #CCC solid;}");
            sb.Append(".page_link_full a:visited{text-decoration:none;color:#195CB5;border:1px #CCC solid;}");
            sb.Append(".page_link_full a:hover{text-decoration:underline;color:#ff6000;border:1px #f60 solid;}");
            sb.Append(".page_link_full a:active{text-decoration:none;color:#195CB5;border:1px #CCC solid;}");
            sb.Append(".page_link_full span{float:left;}");
            sb.Append(".page_link_full .current{border:1px #4398ce solid;margin:1px;height:18px;line-height:18px;padding: 1px 6px;text-align:center;background:#4398ce;color:#fff;}");
            sb.Append(".page_link_full .page_up{background:url(images/pageCtrol/page_up.gif) no-repeat 8px 7px;}");
            sb.Append(".page_link_full .page_up a{padding:1px 5px 1px 15px;_padding:2px 5px 0px 15px;}");
            sb.Append(".page_link_full .page_down{background:url(images/pageCtrol/page_down.gif) no-repeat 47px 7px;}");
            sb.Append(".page_link_full .page_down a{padding:1px 15px 1px 5px;_padding:2px 15px 0px 5px;}");
            sb.Append(".page_link_full .num{color:#808080;height:18px;line-height:18px;padding:4px 2px 2px 10px;}");
            sb.Append(".page_link_full .dian{height:18px;padding-top:4px;color:#808080;margin:0 1px;}");
            sb.Append("</style>");
            return sb.ToString();
        }
        #endregion

        #region 分页函数(控件+样式)迷你版
        /// <summary>
        /// 分页控件+分页样式合集迷你版
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagersWithCssMin(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title)
        {
            return GetDisplayPagersCssMin() + DisplayPagersMin(currentPage, totalRecord, perPageCount, strPage, urlLink, title);
        }

        /// <summary>
        /// 分页控件+分页样式合集迷你版
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">true:显示"共?页"|false:不显示</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagersWithCssMin(int currentPage, int totalRecord, int perPageCount, bool strPage, string urlLink, string title)
        {
            if (strPage)
            {
                return GetDisplayPagersCssMin() + DisplayPagersMin(currentPage, totalRecord, perPageCount, "", urlLink, title);
            }
            else
            {
                return GetDisplayPagersCssMin() + DisplayPagersMin(currentPage, totalRecord, perPageCount, " ", urlLink, title);
            }
        }

        /// <summary>
        /// 分页控件迷你版
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <returns></returns>
        public static string DisplayPagersMin(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title)
        {
            return DisplayPagersMin(currentPage, totalRecord, perPageCount, strPage, urlLink, title, 99);
        }

        /// <summary>
        /// 分页控件迷你版
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalRecord">记录总条数</param>
        /// <param name="perPageCount">每页显示条数</param>
        /// <param name="strPage">自由内容,传入空则为"共?页",支持格式:"{0}{1}{2}",总页数,当前页数,总记录条数</param>
        /// <param name="urlLink">分页地址</param>
        /// <param name="title">写在"第N页"之前的话:鼠标放在页码上会有 title + "第N页"</param>
        /// <param name="maxPages">允许呈现的最大页码</param>
        /// <returns></returns>
        public static string DisplayPagersMin(int currentPage, int totalRecord, int perPageCount, string strPage, string urlLink, string title, int maxPages)
        {
            int totalPageCount = 1;//总页数
            //int maxPages = 99;//允许呈现的最大页码

            if (totalRecord % perPageCount == 0)
            {
                totalPageCount = (totalRecord / perPageCount);
            }
            else
            {
                totalPageCount = (totalRecord / perPageCount) + 1;
            }

            if (totalPageCount >= maxPages)//限定页数不超过maxPages(99)
            {
                totalPageCount = maxPages;
            }

            if (currentPage > totalPageCount)//如果当前页数大于总页数,调整为最后页
            {
                currentPage = totalPageCount;
            }
            if (currentPage <= 0)//如果当前页数小于等于0,调整为第一页
            {
                currentPage = 1;
            }

            //开始组合分页控件
            StringBuilder strControl = new StringBuilder();
            strControl.Append("<div class='page_link_min'>");
            if (string.IsNullOrEmpty(strPage))//默认为"共?页"
            {
                try
                {
                    strControl.AppendFormat("<span class='num'>{1}/{0}</span>   ", totalPageCount, currentPage);
                }
                catch
                {
                    strControl.AppendFormat("<span class='num'>{1}/{0}</span>   ", totalPageCount, currentPage);
                }
            }
            else
            {
                try
                {
                    strControl.AppendFormat(strPage, totalPageCount, currentPage, totalRecord);
                }
                catch
                {
                    strControl.AppendFormat("<span class='num'>{1}/{0}</span>   ", totalPageCount, currentPage);
                }
            }

            if (currentPage > 1)//如果当前页不等于1,则显示上一页可点击
            {
                strControl.AppendFormat("<span class='page_up link01'><a title='上一页' href='" + urlLink + "'>上一页</a></span>", (currentPage - 1).ToString());
            }
            else//灰化,不可点击
            {
                strControl.AppendFormat("<span class='page_up_disable dis'><a></a></span>", (currentPage - 1).ToString());
            }

            if (currentPage != totalPageCount)//如果当前页不是最后一页,则下一页按钮可点击
            {
                strControl.AppendFormat("<span class='page_down link01'><a title='下一页' href='" + urlLink + "'>下一页</a></span>", (currentPage + 1).ToString());
            }
            else//灰化,不可点击
            {
                strControl.AppendFormat("<span class='page_down_disable dis'><a></a></span>", (currentPage + 1).ToString());
            }
            strControl.Append("</div>");//分页控件组合完毕

            if (totalRecord <= perPageCount)//只有一页的不显示分页控件
            {
                return "";
            }
            return strControl.ToString();
        }

        /// <summary>
        /// 分页控件样式迷你版
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayPagersCssMin()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style>");
            sb.Append(".page_link_min {padding:0px 0px;text-align:right;font-size:12px;float:right;font-family:'宋体';line-height:18px;height:24px;}");
            sb.Append(".page_link_min a{border:1px #eee solid;padding:1px 5px;margin:1px 2px;color:#036CB4;text-decoration:none;float:left;height:18px;line-height:18px;}");
            sb.Append(".page_link_min a:link{color:#195CB5;text-decoration:none;border:1px #CCC solid;}");
            sb.Append(".page_link_min a:visited{text-decoration:none;color:#195CB5;border:1px #CCC solid;}");
            sb.Append(".page_link_min a:hover{text-decoration:underline;color:#ff6000;border:1px #f60 solid;}");
            sb.Append(".page_link_min a:active{text-decoration:none;color:#195CB5;border:1px #CCC solid;}");
            sb.Append(".page_link_min .dis a:link,.page_link .dis a:visited,.page_link .dis a:hover,.page_link .dis a:active{text-decoration:none;color:#808080;border:1px #CCC solid;}");
            sb.Append(".page_link_min span{float:left;}");
            sb.Append(".page_link_min .page_up{background:url(images/pageCtrol/page_up.gif) no-repeat 9px 7px;}");
            sb.Append(".page_link_min .page_up_disable{background:url(images/pageCtrol/page_up_disable.gif) no-repeat 9px 6px;}");
            sb.Append(".page_link_min .page_up a{padding:1px 5px 1px 15px;_padding:2px 5px 0px 15px;}");
            sb.Append(".page_link_min .page_up_disable a{padding:1px 5px 1px 15px;_padding:2px 5px 0px 15px;border:1px #CCC solid;color:#808080;}");
            sb.Append(".page_link_min .page_down{background:url(images/pageCtrol/page_down.gif) no-repeat 47px 7px;}");
            sb.Append(".page_link_min .page_down_disable{background:url(images/pageCtrol/page_down_disable.gif) no-repeat 9px 5px;}");
            sb.Append(".page_link_min .page_down a{padding:1px 15px 1px 5px;_padding:2px 15px 0px 5px;}");
            sb.Append(".page_link_min .page_down_disable a{padding:1px 15px 1px 5px;_padding:2px 15px 0px 5px;border:1px #CCC solid;color:#808080;}");
            sb.Append(".page_link_min .num{color:#808080;height:18px;line-height:18px;padding:4px 2px 2px 10px;}");
            sb.Append("</style>");
            return sb.ToString();
        }
        #endregion
    }
}
