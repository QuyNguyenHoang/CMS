using CMS.Core.Repositories;

namespace CMS.Infrastructure.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        Task<int> CompleteAsync();
    }
}
