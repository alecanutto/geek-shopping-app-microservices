using GeekShooping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.Category.API.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVO>>> FindAll()
        {
            var Categorys = await _repository.FindAll();
            return Ok(Categorys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVO>> FindById(long id)
        {
            var Category = await _repository.FindById(id);
            if (Category == null) return NotFound();
            return Ok(Category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryVO>> Create([FromBody] CategoryVO vo)
        {
            if (vo == null) return BadRequest();
            var category = await _repository.Create(vo);
            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryVO>> Update([FromBody] CategoryVO vo)
        {
            if (vo == null) return BadRequest();
            var category = await _repository.Update(vo);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryVO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
