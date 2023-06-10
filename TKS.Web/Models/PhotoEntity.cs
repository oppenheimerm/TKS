
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TKS.Web.Helpers;

namespace TKS.Web.Models
{
    public class PhotoEntity
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

        public string UrlName
        {
            get
            {
                return DisplayName.Replace(" ", "%20").ToLowerInvariant();
            }
        }


        [Required]
        [ForeignKey("Folder")]
        public int FolderId { get; set; }
        public FolderEntity? Folder { get; set; }
       
        public override string ToString()
        {
            return $"Photo: {Name}";
        }


        public string ThumbnailDirectory
        {
            get
            {
                return $"/{Constants.ProductImageFolder}/{Folder.GetFolderUrl()}/thumbnail/";
            }
        }

        public string Link
        {
            get
            {
                return $"/photo/{Folder.FolderName}/{UrlName}/";
            }
        }

        /*public string DownloadLink
        {
            get
            {
                return $"/albums/{Folder.GetFolderUrl()}/{Name.Replace(" ", "%20").ToLowerInvariant()}";
            }
        }*/

        public string? GetThumbnailLink(int width, out int height)
        {
            string ext = Path.GetExtension(Name);

            if (_heights.TryGetValue(width, out height))
            {
                return GenerateThumbnailLink(width, height, ext);
            }

            string absoluteDir = Path.Combine(Path.GetDirectoryName(Folder.AbsolutePath), Folder.FolderName, "thumbnail");
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
