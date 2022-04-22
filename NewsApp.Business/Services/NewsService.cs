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
    public class NewsService:INewsService
    {
        private readonly IBaseRepository<News> _baseRepository;
        private readonly IMapper _mapper;
        public NewsService(IBaseRepository<News> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(NewsDto newsDto)
        {
            var news = _mapper.Map<News>(newsDto);
            await _baseRepository.AddAsync(news);
        }

        public async Task<PagedResponseModel<NewsDto>> PagedQueryAsync(string keySearch, int page, int limit)
        {
            var query = _baseRepository.Entities;
            var news = await query
               .AsNoTracking()
               .PaginateAsync(page, limit);

            return new PagedResponseModel<NewsDto>
            {
                CurrentPage = news.CurrentPage,
                TotalPages = news.TotalPages,
                TotalItems = news.TotalItems,
                Items = _mapper.Map<IEnumerable<NewsDto>>(news.Items)
            };
        }

        public async Task<IEnumerable<NewsDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<NewsDto>>(await _baseRepository.GetAllByAsync(m=>true, "Type, User, "));
        }

        public async Task<NewsDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<NewsDto>(await _baseRepository.GetByIdAsync(id));

        }
        public async Task UpdateAsync(NewsDto NewsDto)
        {
            var news = _mapper.Map<News>(NewsDto);
            await _baseRepository.UpdateAsync(news);
        }

        public async Task DeleteAsync(NewsDto NewsDto)
        {
            await _baseRepository.DeleteAsync(NewsDto.Id);
        }
    }
}
