namespace TKS.UseCases
{
    public interface ICategoryCodeUniqueUseCase
    {
        Task<bool> ExecuteAsync(string categoryCode);
    }
}
