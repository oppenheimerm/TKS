using Microsoft.Extensions.Logging;
using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public class FolderDbEntityRepository : IFolderDbEntityRepository
    {
        private readonly ILogger<FolderDbEntityRepository> Logger;
        private readonly ApplicationDbContext Context;
        public FolderDbEntityRepository(ILogger<FolderDbEntityRepository> logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<(FolderEntity, bool Success, string ErrorMessage)> Add(FolderEntity folder)
        {
            try
            {
                Context.ProductPhotoFolders.Add(folder);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Folder with Id: {folder.Id}, and name: {folder.FolderName}, added to database at: {DateTime.UtcNow}");
                return (folder, true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to add product to database. Timestamp : {DateTime.UtcNow}");
                return (folder, false, ex.ToString());
            }
        }
    }
}
