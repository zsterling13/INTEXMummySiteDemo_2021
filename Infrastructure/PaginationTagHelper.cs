using INTEX2Mock.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Infrastructure
{
    //Sets up for the PaginationTagHelper to look for every div tag that uses the "page-info" class attribute
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        //Creates a UrlHelperFactory variable
        private IUrlHelperFactory urlInfo;

        //Constructor
        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        //teamName string variable that is interacted with
        public string teamName { get; set; }

        //PagenumberingInfo object for info in regards to the page info that Pagination needs to know
        public PageNumberingInfo PageInfo { get; set; }

        //Own dictionary that has key value pairs that we are creating
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        //Creates a ViewContext Object
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        //Main method that helps create the HTML for each pagination link that shows up
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            TagBuilder finishedTag = new TagBuilder("div");

            IUrlHelper UrlHelp = urlInfo.GetUrlHelper(ViewContext);

            //Main loop that runs through and creates every a tag for every page link dynamically
            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                individualTag.Attributes["href"] = UrlHelp.Action("ViewMummyRecords", KeyValuePairs);
                individualTag.Attributes["style"] = "margin:3%";
                individualTag.InnerHtml.Append(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);
            }
            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}
