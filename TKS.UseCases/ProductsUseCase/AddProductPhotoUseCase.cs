
using Microsoft.AspNetCore.Http;
using TKS.Datastore.EFCore;

namespace TKS.UseCases.ProductsUseCase
{
    public class AddProductPhotoUseCase : IAddProductPhotoUseCase
    {
        private readonly IPhotoFileRepository PhotoFileRepository;
        public AddProductPhotoUseCase(IPhotoFileRepository photoFileRepository)
        {
            PhotoFileRepository = photoFileRepository;
        }

        public async Task<(FileInfo FileInfo, bool Success, string ErrorMessage)> ExecuteAsync(IFormFile file, string folderName)
        {
            var response = await PhotoFileRepository.AddPhotoAsync(file, folderName);
            return response;
        }
    }
}
