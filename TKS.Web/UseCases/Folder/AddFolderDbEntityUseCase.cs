using TKS.Web.Models;
using TKS.Web.Repositories;

namespace TKS.Web.UseCases.Folder
{
    public class AddFolderDbEntityUseCase : IAddFolderDbEntityUseCase
    {
        private readonly IFolderDbEntityRepository FolderDbEntityRepository;
        public AddFolderDbEntityUseCase(IFolderDbEntityRepository folderDbEntityRepository)
        {
            FolderDbEntityRepository = folderDbEntityRepository;
        }

        public async Task<(FolderEntity FolderDbEntity, bool Success, string ErrorMessage)> ExecuteAsync(FolderEntity folder)
        {
            var response = await FolderDbEntityRepository.Add(folder);
            return response;
        }
    }
}
