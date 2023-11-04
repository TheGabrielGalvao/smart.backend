using AutoMapper;
using Domain.Entities.Stock;
using Domain.Enum;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Repository.Stock;
using Domain.Interface.Service.Stock;
using Domain.Model.Product;
using Domain.Model.Stock;
using Service.Common;

namespace Service.Stock
{
    public class InventoryAdjustmentService : BaseService<InventoryAdjustmentEntity, InventoryAdjustmentRequest, InventoryAdjustmentResponse>, IInventoryAdjustmentService
    {
        private IStockLocationRepository _locationRepository;
        private IProductRepository _productRepository;
        private IStockReleaseRepository _releaseRepository;
        public InventoryAdjustmentService(IInventoryAdjustmentRepository repository,  IMapper mapper, IUnitOfWork uow, IStockLocationRepository locationRepository, IProductRepository producRepository, IStockReleaseRepository releaseRepository)
            : base(repository, mapper, uow)
        {
            _locationRepository = locationRepository;
            _productRepository = producRepository;
            _releaseRepository = releaseRepository;
        }

        public override async Task<InventoryAdjustmentResponse> Create (InventoryAdjustmentRequest request)
        {
            try
            {
                var stockLocation = await _locationRepository.Get();
                var product = await _productRepository.Get(request.ProductUuid);

                var adjustmentEntity = new InventoryAdjustmentEntity()
                {
                    StockLocation = stockLocation.FirstOrDefault(),
                    StockLocationId = stockLocation.FirstOrDefault().Id,
                    Product = product,
                    ProductId = product.Id,
                    Amount = request.Amount,
                    Description = request.Description,
                    Flow = request.Flow,
                    UpdatedAt = DateTime.Now,
                    Status = EStockReleaseStatus.RELEASED

                };

                var stockRelease = new StockReleaseEntity() { };


                await _repository.Create(adjustmentEntity);
                


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
