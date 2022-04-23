using Microsoft.AspNetCore.Mvc;
using NewsApp.Business.Interfaces;
using NewsApp.Contracts;
using NewsApp.Contracts.Dtos;
using NewsApp.Models;

namespace NewsApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;   
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<PagedResponseModel<CommentsDto>> GetAllNewsAsync(PageFilter filter)
        {
            return await _commentService.GetAllCommentByNewsAsync(filter);
        }

        // GET api/<NewsController>/5
        /*[HttpGet("{id}")]
        public async Task<NewsDto> Get(Guid id)
        {
*//*            return await _commentService.GetByIdAsync(id);
*//*        }*/
    }
}
