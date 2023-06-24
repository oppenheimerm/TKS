

using TKS.Datastore.EFCore;

namespace TKS.UseCases.Folder
{
    public class AddFolderUseCase : IAddFolderUseCase
    {
        private readonly IFolderFileRepository FolderFileRepository;
        public AddFolderUseCase(IFolderFileRepository folderFileRepository)
        {
            FolderFileRepository = folderFileRepository;
        }

        public async Task<(DirectoryInfo DirectoryInfo, bool Success, string ErrorMessage)> ExecuteAsync()
        {
            var response = await FolderFileRepository.CreateFolderAsync();
            return response;
        }
    }
}
