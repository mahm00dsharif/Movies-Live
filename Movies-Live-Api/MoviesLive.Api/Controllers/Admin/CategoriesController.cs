using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesLive.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace MoviesLive.Api.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository _repository;
        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetListAsync<Category>());
        }
    }
}
