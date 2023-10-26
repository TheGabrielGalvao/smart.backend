using Domain.Entities.Product;

namespace Domain.Interface.Repository.Product
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> Get();
        Task<ProductCategory> Get(Guid uuid);
        Task<ProductCategory> Create(ProductCategory user);

        Task<ProductCategory> Update(ProductCategory user);

        Task Delete(Guid uuid);
    }
}
