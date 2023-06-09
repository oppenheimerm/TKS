
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TKS.Core
{
    public class ProductPhoto
    {
        private Dictionary<int, int> _heights = new Dictionary<int, int>();
        private static Regex _size = new Regex(@"(?<name>.+)-(?<width>[0-9]+)x(?<height>[0-9]+).", RegexOptions.Compiled);

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// filename with extension
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// filename without extension
        /// </summary>
        [Required]
        public string DisplayName { get; set; } = string.Empty;


        // 
        // //  //C:\Users\moppenheimer\repo\web\MIH\MIH.Web\wwwroot\ProductPhotos\Thumbnails
        [Required]
        public string? AbsolutePath { get; set; }

        public string UrlName
        {
            get
            {
                return DisplayName.Replace(" ", "%20").ToLowerInvariant();
            }
        }


        public override string ToString()
        {
            return $"Photo: {Name}";
        }

        public string ThumbnailDirectory
        {
            get
            {
                return $"/ProductPhotos/Thumbnails/";
            }
        }

        public string Link
        {
            get
            {
                return $"/photo/ProductPhotos/{UrlName}/";
            }
        }



        public string? GetThumbnailLink(int width, out int height)
        {
            string ext = Path.GetExtension(Name);

            if (_heights.TryGetValue(width, out height))
            {
                return GenerateThumbnailLink(width, height, ext);
            }


            string absoluteDir = Path.Combine(Path.GetDirectoryName(AbsolutePath), "Thumbnails");



            string pattern = $"{DisplayName}-{width}x*{ext}";
            var thumbnail = Directory.GetFiles(absoluteDir, pattern).FirstOrDefault();

            if (!string.IsNullOrEmpty(thumbnail))
            {
                string fileName = Path.GetFileName(thumbnail);
                Match match = _size.Match(fileName);

                if (match.Success)
                {
                    height = int.Parse(match.Groups["height"].Value);
                    _heights[width] = height;
                    return GenerateThumbnailLink(width, height, ext);
                }
            }

            return null;
        }

        private string GenerateThumbnailLink(int width, int height, string ext)
        {
            return $"{ThumbnailDirectory}{UrlName}-{width}x{height}{ext}";
        }
    }
}
