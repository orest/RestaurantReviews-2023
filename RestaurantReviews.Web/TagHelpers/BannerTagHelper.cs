using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RestaurantReviews.Web.TagHelpers {
    [HtmlTargetElement("banner")]
    public class BannerTagHelper : TagHelper {
        public string Title { get; set; }
        public string Intro { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.Content.SetHtmlContent($@"
<div class=""p-5 mb-4 bg-light rounded-3"">
      <div class=""container-fluid"">
        <h1 class=""display-5 fw-bold"">{Title}</h1>
        <p class=""col-md-8 fs-4"">{Intro}</p>
        
      </div>
    </div>
");
            //base.Process(context, output);
        }
    }
}
