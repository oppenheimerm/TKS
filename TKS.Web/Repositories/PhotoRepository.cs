namespace TKS.Web.Repositories
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
