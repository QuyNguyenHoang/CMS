using CMS.Core.Repositories;

namespace CMS.Infrastructure.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        IPostCategoryRepository PostCategories { get; }
        ISeriesRepository Series { get; }

        Task<int> CompleteAsync();
    }
}
