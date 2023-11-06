using AutoMapper;
using Domain.Entities.Stock;
using Domain.Enum;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Repository.Stock;
using Domain.Interface.Service.Stock;
using Domain.Model.Stock;
using Service.Common;

namespace Service.Stock
{
    public class InventoryAdjustmentService : BaseService<InventoryAdjustmentEntity, InventoryAdjustmentRequest, InventoryAdjustmentResponse>, IInventoryAdjustmentService
    {
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private IStockReleaseService _releaseService;

        public InventoryAdjustmentService(IInventoryAdjustmentRepository repository,  IMapper mapper, IUnitOfWork uow, IProductRepository producRepository, IUserRepository userRepository, IStockReleaseService releaseService)
            : base(repository, mapper, uow)
        {
            _productRepository = producRepository;
            _userRepository = userRepository;
            _releaseService = releaseService;
        }

        public override async Task<InventoryAdjustmentResponse> Create (InventoryAdjustmentRequest request)
        {
            try
            {
                var users = await _userRepository.Get();
                var user = users.Where(x => x.Email == "admin@teste.com").FirstOrDefault();

                var product = await _productRepository.Get(request.ProductUuid);


                var adjustmentEntity = new InventoryAdjustmentEntity()
                {
                    StockLocation = product.StockLocation,
                    StockLocationId = product.StockLocationId,
                    Product = product,
                    ProductId = product.Id,
                    Amount = request.Amount,
                    Description = request.Description,
                    Flow = request.Flow,
                    UpdatedAt = DateTime.Now,
                    Status = EStockReleaseStatus.RELEASED

                };
                

                await _repository.Create(adjustmentEntity);

                await _releaseService.StockProcessor(product, adjustmentEntity.Flow, adjustmentEntity.Amount, (int)adjustmentEntity.Id, user);


                _uow.Commit();
                return _mapper.Map<InventoryAdjustmentResponse>(adjustmentEntity);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }

        
    }
}

