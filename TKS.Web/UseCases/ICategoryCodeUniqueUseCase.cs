namespace TKS.Web.UseCases
{
    public interface ICategoryCodeUniqueUseCase
    {
        Task<bool> ExecuteAsync(string categoryCode);
    }
}
