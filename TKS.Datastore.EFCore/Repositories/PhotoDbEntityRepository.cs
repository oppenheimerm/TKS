

using Microsoft.Extensions.Logging;
using TKS.Core.Models;

namespace TKS.Datastore.EFCore
{
    public class PhotoDbEntityRepository : IPhotoDbEntityRepository
    {
        private readonly ILogger<PhotoDbEntityRepository> Logger;
        private readonly ApplicationDbContext Context;
        public PhotoDbEntityRepository( ILogger<PhotoDbEntityRepository>logger, ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<(PhotoEntity Photo, bool Success, string ErrorMessage)> Add(PhotoEntity photo)
        {
            try
            {
                Context.ProductPhotos.Add(photo);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Photo with Id: {photo.Id}, and name: {photo.Name}, added to database at: {DateTime.UtcNow}");
                return (photo, true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to add photo entity to database. Timestamp : {DateTime.UtcNow}");
                return (photo, false, ex.ToString());
            }
        }
    }
}
