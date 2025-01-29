using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTAgHelper.TagHelpers
{
    [HtmlTargetElement("customImage")]
    public class ImageTagHelper:TagHelper
    {
        public string ALT { get; set; }
        public string SRC { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "image";
            output.Attributes.Add("src", SRC);
            output.Attributes.Add("alt", ALT);

           output.TagMode=TagMode.SelfClosing;
        }
    }
}
