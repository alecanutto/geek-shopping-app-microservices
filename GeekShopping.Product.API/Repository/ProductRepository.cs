using AutoMapper;
using GeekShooping.Product.API.Data.ValueObjects;
using GeekShooping.Product.API.Model.Context;
using GeekShopping.Product.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Model.Product> products = await _dbContext.Products.Include(p => p.Category).ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Model.Product product = await _dbContext.Products.Where(p => p.Id == id).Include(p => p.Category).FirstAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Model.Product product = _mapper.Map<Model.Product>(vo);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Model.Product product = _mapper.Map<Model.Product>(vo);
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Model.Product product = await _dbContext.Products.Where(p => p.Id == id).FirstAsync();
                if (product == null) return false;
                _dbContext.Products.Remove(product);
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
