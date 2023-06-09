using Microsoft.EntityFrameworkCore;
using TKS.Web.Data;
using TKS.Web.Helpers;

namespace TKS.Web.Repositories
{
    public class FolderFileRepository : IFolderFileRepository
    {
        private IWebHostEnvironment Environment;
        private readonly ILogger<FolderFileRepository> Logger;
        private readonly ApplicationDbContext Context;

        public FolderFileRepository(IWebHostEnvironment environment, ILogger<FolderFileRepository> logger,
            ApplicationDbContext context)
        {
            Environment = environment;
            Logger = logger;
            Context = context;
        }

        public async Task<(DirectoryInfo directoryInfo, bool Success, string ErrorMessage)> CreateFolderAsync()
        {
            var name = await GetNewFolderFileName();
            string path = Path.Combine(Environment.WebRootPath, Constants.ProductImageFolder, name);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {

                if (!Directory.Exists(path))
                {
                    await Task.Run(() => {
                        Directory.CreateDirectory(path);
                        Logger.LogInformation($"Folder: {name} created at {DateTime.UtcNow} at location: {path}");
                    });

                    directoryInfo = new DirectoryInfo(path);

                    return (directoryInfo, true, string.Empty);
                }
                else
                {
                    Logger.LogWarning($"Failed to create folder.  Folder: {name} already exist.");
                    return (directoryInfo, false, "Folder already exist");
                }
            }
            catch (Exception Ex)
            {
                Logger.LogError($"Unable to create folder. Exception: {Ex.ToString()} at {DateTime.Now}");
                return (directoryInfo, false, Ex.Message);
            }
        }

        private async Task<string> GetNewFolderFileName()
        {
            var internalFilename = FolderNameGenerator.Generate();
            var filenameExist = await FolderFileNameExist(internalFilename);
            while (filenameExist)
            {
                internalFilename = FolderNameGenerator.Generate();
            }
            return internalFilename;
        }

        public async Task<bool> FolderFileNameExist(string fileName)
        {
            return (await Context.ProductPhotoFolder.AnyAsync(f => f.FolderName == fileName));
        }
    }
}
