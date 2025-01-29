using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTAgHelper.TagHelpers
{
    [HtmlTargetElement("customButton")]
    public class buttonTagHelper:TagHelper
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("Type", Type);
            output.Attributes.Add("Value", Value);

            output.Content.SetContent(Value);
        }
    }
}
