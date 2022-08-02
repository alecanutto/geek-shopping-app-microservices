using GeekShooping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryVO>> FindAll();

        Task<CategoryVO> FindById(long id);

        Task<CategoryVO> Create(CategoryVO vo);

        Task<CategoryVO> Update(CategoryVO vo);

        Task<bool> Delete(long id);
    }
}
