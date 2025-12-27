using AutoMapper;
using CMS.Core.Domain.Content;
using CMS.Core.Models.Content;
using CMS.Core.Models;
using Microsoft.EntityFrameworkCore;
using CMS.Core.Repositories;

namespace CMS.Infrastructure.Repositorires
{
    public class PostCategoryRepository : RepositoryBase<PostCategory, Guid>, IPostCategoryRepository
    {
        private readonly IMapper _mapper;
        public PostCategoryRepository(CMS_DBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<PagedResult<PostCategoryDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.PostCategories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            var totalRow = await query.CountAsync();

            query = query.OrderByDescending(x => x.DateCreated)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize);

            return new PagedResult<PostCategoryDto>
            {
                Results = await _mapper.ProjectTo<PostCategoryDto>(query).ToListAsync(),
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
        }
    }
}
