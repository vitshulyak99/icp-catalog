using System.Linq;
using System.Threading.Tasks;
using Markdig;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Collections.TagHelpers
{
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        private readonly MarkdownPipeline _pipeline;

        [HtmlAttributeName("markdown")] public ModelExpression Markdown { get; set; }

        [HtmlAttributeName("max-length")] public int? MaxLength { get; set; } = null;

        [HtmlAttributeName("class")] public string Class { get; set; }

        public MarkdownTagHelper(MarkdownPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            string content = null;

            if (Markdown != null)
            {
                content = Markdown?.Model.ToString();
            }

            content ??= (await output.GetChildContentAsync(NullHtmlEncoder.Default))
                .GetContent(NullHtmlEncoder.Default);
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            
            var b = content.Trim().Trim('\n', '\r').TrimEnd().TrimStart();
            var html = Markdig.Markdown.ToHtml(MaxLength.HasValue && MaxLength.Value < b.Length ? b.Substring(0,MaxLength.Value): b,_pipeline);
            output.Content.SetHtmlContent(html);
        }
    }
}