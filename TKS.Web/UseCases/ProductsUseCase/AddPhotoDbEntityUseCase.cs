using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.ProductsUseCase
{
    public class AddPhotoDbEntityUseCase: IAddPhotoDbEntityUseCase
    {
        private readonly IPhotoDbEntityRepository PhotoDbEntityRepository;
        public AddPhotoDbEntityUseCase(IPhotoDbEntityRepository photoDbEntityRepository)
        {
            PhotoDbEntityRepository = photoDbEntityRepository;
        }

        public async Task<(PhotoEntity PhotoEntity, bool Success, string ErrorMessage)> ExecuteAsync(PhotoEntity photo)
        {
            var response = await PhotoDbEntityRepository.Add(photo);
            return response;
        }
    }
}
