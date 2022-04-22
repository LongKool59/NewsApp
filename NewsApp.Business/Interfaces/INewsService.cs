using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Contracts;
using NewsApp.Contracts.Dtos;

namespace NewsApp.Business.Interfaces
{
    public interface INewsService
    {
        Task AddAsync(NewsDto newsDto);

        Task<PagedResponseModel<NewsDto>> PagedQueryAsync(string keySearch,int page, int limit);

        Task<IEnumerable<NewsDto>> GetAllAsync();

        Task<NewsDto> GetByIdAsync(Guid id);
        Task UpdateAsync(NewsDto newsDto);

        Task DeleteAsync(NewsDto newsDto);
    }
}
