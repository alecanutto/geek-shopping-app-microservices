using AutoMapper;
using GeekShooping.Product.API.Data.ValueObjects;
using GeekShooping.Product.API.Model.Context;
using GeekShopping.Product.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.Product.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _dbContext;
        private IMapper _mapper;

        public CategoryRepository(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryVO>> FindAll()
        {
            List<Model.Category> categories = await _dbContext.Categories.ToListAsync();
            return _mapper.Map<List<CategoryVO>>(categories);
        }

        public async Task<CategoryVO> FindById(long id)
        {
            Model.Category category = await _dbContext.Categories.Where(p => p.Id == id).FirstAsync();
            return _mapper.Map<CategoryVO>(category);
        }

        public async Task<CategoryVO> Create(CategoryVO vo)
        {
            Model.Category category = _mapper.Map<Model.Category>(vo);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryVO>(category);
        }

        public async Task<CategoryVO> Update(CategoryVO vo)
        {
            Model.Category category = _mapper.Map<Model.Category>(vo);
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryVO>(category);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Model.Category category = await _dbContext.Categories.Where(p => p.Id == id).FirstAsync();
                if (category == null) return false;
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
