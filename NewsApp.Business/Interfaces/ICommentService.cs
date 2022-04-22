using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Contracts;
using NewsApp.Contracts.Dtos;

namespace NewsApp.Business.Interfaces
{
    public interface ICommentService
    {
        Task AddAsync(CommentsDto commentDto);

        Task<PagedResponseModel<CommentsDto>> PagedQueryAsync(string keySearch,int page, int limit);

        Task<IEnumerable<CommentsDto>> GetAllAsync();

        Task<CommentsDto> GetByIdAsync(Guid id);
        Task UpdateAsync(CommentsDto commentDto);

        Task DeleteAsync(CommentsDto commentDto);
    }
}
