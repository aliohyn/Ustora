using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ustora.Web.ViewModels;

namespace Ustora.Web.Infrastructure.TagHelpers
{
    [HtmlTargetElement("nav", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel.TotalPages > 1) {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder ul = new TagBuilder("ul");
                ul.Attributes["class"] = "pagination";
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder a = new TagBuilder("a");
                    a.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                    a.InnerHtml.Append(i.ToString());
                    li.InnerHtml.AppendHtml(a);
                    ul.InnerHtml.AppendHtml(li);
                }
                output.Content.AppendHtml(ul);
            }
        }
    }
}
