using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Business.Interfaces;
using NewsApp.Contracts.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService; 
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
        {
            return await _newsService.GetAllAsync();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<NewsDto> Get(Guid id)
        {
            return await _newsService.GetByIdAsync(id);
        }
    }
}
