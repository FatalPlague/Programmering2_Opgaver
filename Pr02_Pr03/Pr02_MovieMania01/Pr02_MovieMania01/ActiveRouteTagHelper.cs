using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Pr02_MovieMania01
{
    [HtmlTargetElement(Attributes = "asp-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string? Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string? Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsActive())
            {

                var classes = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value;
                output.Attributes.SetAttribute("class", $"bg-secondary text-white rounded {classes}");
            }
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext? ViewContext { get; set; }

        private bool IsActive()
        {
            var currentController = ViewContext?.RouteData.Values["Controller"]?.ToString();
            var currentAction = ViewContext?.RouteData.Values["Action"]?.ToString();

            var active = false;
            if (!String.IsNullOrWhiteSpace(Controller) &&
                Controller.Equals(currentController, StringComparison.CurrentCultureIgnoreCase))
            {
                active = true;
            }
            if (active &&
                !String.IsNullOrWhiteSpace(Action) &&
                Action.Equals(currentAction, StringComparison.CurrentCultureIgnoreCase))
            {
                active = true;
            }
            else
            {
                active = false;
            }

            return active;
        }
    }
}
