using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApp.Business.Interfaces;
using NewsApp.Contracts;
using NewsApp.Contracts.Dtos;
using NewsApp.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Business.Services
{
    public class CommentsService:ICommentService
    {
       
        private readonly IBaseRepository<Comments> _baseRepository;
        private readonly IMapper _mapper;
        public CommentsService(IBaseRepository<Comments> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CommentsDto commentDto)
        {
            var comments = _mapper.Map<Comments>(commentDto);
            await _baseRepository.AddAsync(comments);
        }
        public async Task<PagedResponseModel<CommentsDto>> GetAllCommentByNewsAsync(int page, int limit)
        {
            var query = _baseRepository.Entities;
            query=query.Where(m=>m.Published==true);
            var comments = await query
               .AsNoTracking()
               .PaginateAsync(page, limit);

            return new PagedResponseModel<CommentsDto>
            {
                CurrentPage = comments.CurrentPage,
                TotalPages = comments.TotalPages,
                TotalItems = comments.TotalItems,
                Items = _mapper.Map<IEnumerable<CommentsDto>>(comments.Items)
            };
        }
        public Task UpdateAsync(CommentsDto commentDto)
        {
            return Task.CompletedTask;
        }
        public async Task DeleteAsync(CommentsDto commentDto)
        {
            var comment = await _baseRepository.GetByIdAsync(commentDto.Id);
            if(comment != null)
            {
                comment.Published = false;
            }
            await _baseRepository.UpdateAsync(comment);
        }


    }
}
