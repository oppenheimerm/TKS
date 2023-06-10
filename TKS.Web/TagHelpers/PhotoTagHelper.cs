using Microsoft.AspNetCore.Razor.TagHelpers;
using TKS.Web.Helpers.Imaging;
using TKS.Web.Models;

namespace TKS.Web.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "photo, type")]
    public class PhotoTagHelper : TagHelper
    {
        public PhotoEntity? Photo { get; set; }
        public ImageType Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string thumbnail = Photo.GetThumbnailLink((int)Type, out int height);

            if (string.IsNullOrEmpty(thumbnail))
            {
                output.SuppressOutput();
                return;
            }

            output.Attributes.SetAttribute("width", (int)Type);
            output.Attributes.SetAttribute("height", height);
            output.Attributes.SetAttribute("alt", Photo.DisplayName);
            output.Attributes.SetAttribute("src", thumbnail);

            if (Type != ImageType.Full)
            {
                string thumb = Photo.GetThumbnailLink((int)ImageType.Thumbnail, out int thumbHeight);
                string cover = Photo.GetThumbnailLink((int)ImageType.Cover, out int coverHeight);
                output.Attributes.SetAttribute("srcset", $"{thumb} 1x, {cover} 2x");
            }
        }
    }
}
