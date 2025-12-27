using CMS.Core.Domain.Content;
using CMS.Core.Models.Content;
using CMS.Core.Models;
using CMS.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory, Guid>
    {
        Task<PagedResult<PostCategoryDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10);
    }
}
