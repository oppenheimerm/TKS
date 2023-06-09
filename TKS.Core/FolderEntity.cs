

using System.ComponentModel.DataAnnotations;

namespace TKS.Core
{
    /// <summary>
    /// Represent a folder entity
    /// </summary>
    public class FolderEntity
    {
        [Key]
        public int Id { get; set; }

        public string FolderName { get; set; } = string.Empty;
        public ICollection<PhotoEntity>? Photos { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.Now;
        public string? AbsolutePath { get; set; } = string.Empty;
        public string GetFolderUrl()
        {
            return FolderName.ToLowerInvariant();
        }
    }
}
