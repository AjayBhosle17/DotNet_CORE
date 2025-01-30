using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTAgHelper.TagHelpers
{


    [HtmlTargetElement("*", Attributes = "highlight")]
    public class HighLightTagHelper:TagHelper
    {

        public string highlight { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("style", $"background-color:{highlight}");
        }
    }
}
