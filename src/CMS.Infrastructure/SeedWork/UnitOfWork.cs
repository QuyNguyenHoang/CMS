using AutoMapper;
using CMS.Core.Repositories;
using CMS.Infrastructure.Repositorires;
using CMS.Infrastructure.SeedWorks;

namespace CMS.Infrastructure.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMS_DBContext _context;
        public UnitOfWork(CMS_DBContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }
        public IPostRepository Posts { get; private set; }
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
