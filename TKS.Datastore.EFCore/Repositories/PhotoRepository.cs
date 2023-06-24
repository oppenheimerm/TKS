using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace TKS.Datastore.EFCore
{
    public class PhotoRepository
    {
        private IWebHostEnvironment Environment;
        private readonly ILogger<PhotoRepository> Logger;

        public PhotoRepository(IWebHostEnvironment environment, ILogger<PhotoRepository> logger)
        {
            Environment = environment;
            Logger = logger;
        }
    }
}
