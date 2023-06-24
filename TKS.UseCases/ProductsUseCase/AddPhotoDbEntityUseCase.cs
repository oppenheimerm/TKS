
using TKS.Core.Models;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
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
