using AutoMapper;
using CMS.Core.Domain.Identity;
using CMS.Core.Repositories;
using CMS.Infrastructure.Repositorires;
using CMS.Infrastructure.SeedWorks;
using Microsoft.AspNetCore.Identity;

namespace CMS.Infrastructure.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMS_DBContext _context;

        public UnitOfWork(CMS_DBContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            Posts = new PostRepository(context, mapper, userManager);
            PostCategories = new PostCategoryRepository(context, mapper);
            Series = new SeriesRepository(context, mapper);

        }
        public IPostRepository Posts { get; private set; }
        public IPostCategoryRepository PostCategories { get; private set; }
        public ISeriesRepository Series { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
