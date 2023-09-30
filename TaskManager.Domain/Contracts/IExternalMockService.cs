namespace TaskManager.Domain.Contracts
{
    public interface IExternalMockService
    {
        Task<TRequestObj> PostAsync<TRequestObj>(TRequestObj body, string url, CancellationToken cancellationToken)
            where TRequestObj : class;

        Task<TResponseObj> GetAsync<TResponseObj>(string url, CancellationToken cancellationToken);

        Task DeleteAsync(string url, CancellationToken cancellationToken);
    }
}
