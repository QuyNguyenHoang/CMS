using CMS.Infrastructure.SeedWorks;

namespace CMS.Infrastructure.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMS_DBContext _context;
        public UnitOfWork(CMS_DBContext context)
        {
            _context = context;
        }
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
