using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pens.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {            
            StringBuilder result = new StringBuilder();
            int startPage = pagingInfo.CurrentPage < 6 ? 1 : pagingInfo.CurrentPage - 4;

            if (pagingInfo.TotalPages > 10 && (pagingInfo.TotalPages - pagingInfo.CurrentPage) < 5)
            {
                startPage = pagingInfo.TotalPages - 9;
            }
            if (pagingInfo.TotalPages > 10 && pagingInfo.CurrentPage > 5)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(1));
                tag.InnerHtml = "&laquo;";
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            int i = startPage;
            int numPages = 10;
            if (pagingInfo.TotalPages < 10)
            {
                numPages = pagingInfo.TotalPages;
            }
            while (i < (startPage + numPages))
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
                i++;
            }
            if (pagingInfo.TotalPages > 10 && (pagingInfo.TotalPages - pagingInfo.CurrentPage) > 5)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
                tag.InnerHtml = "&raquo;";                
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}