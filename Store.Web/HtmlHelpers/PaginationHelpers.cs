using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.HtmlHelpers
{
    public static class PaginationHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PaginationInfo paginationInfo, Func<int,string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= paginationInfo.TotalPages; i++)
            {
                TagBuilder aTag = new TagBuilder("a");
                aTag.MergeAttribute("href", pageUrl(i));
                aTag.InnerHtml = i.ToString();
                aTag.AddCssClass("btn btn-default");
                if (i == paginationInfo.CurrentPage)
                {
                    aTag.AddCssClass("selected");
                    aTag.AddCssClass("btn-primary");
                }
                sb.Append(aTag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}