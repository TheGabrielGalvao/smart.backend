using AutoMapper;
using Domain.Entities.Product;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Service.Product;
using Domain.Model.Product;

namespace Service.Product
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _repository;
        public readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public ProductService(IProductRepository repository, IProductCategoryRepository categoryRepository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ProductResponse> Create(ProductRequest request)
        {
            try
            {
                var product = _mapper.Map<ProductEntity>(request);
                var category = _categoryRepository.Get(request.ProductCategoryUuid!.Value).Result;
                
                product.ProductCategory = category;
                product.ProductCategoryId = category.Id;

                await _repository.Create(product);

                _uow.Commit();
                return _mapper.Map<ProductResponse>(product);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }

        public async Task Delete(Guid uuid)
        {
            try
            {
                await _repository.Delete(uuid);
                _uow.Commit();
            }
            catch
            {
                _uow.Rollback();
            }
        }

        public async Task<IEnumerable<ProductResponse>> Get()
        {
            return _mapper.Map<IEnumerable<ProductResponse>>(await _repository.Get());
        }

        public async Task<ProductResponse> Get(Guid uuid)
        {
            return _mapper.Map<ProductResponse>(await _repository.Get(uuid));
        }

        public async Task<ProductResponse> Update(Guid uuid, ProductRequest request)
        {
            try
            {
                var product = await _repository.Get(uuid);

                product.Name = request.Name;
                product.Description = request.Description;
                product.Status = request.Status;

                await _repository.Update(product);
                _uow.Commit();

                return _mapper.Map<ProductResponse>(product);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
