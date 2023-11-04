using AutoMapper;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Repository.Stock;
using Domain.Interface.Service.Stock;
using Domain.Model.Stock;
using Service.Common;

namespace Service.Stock
{
    class StockReleaseService : BaseService<StockReleaseEntity, StockReleaseRequest, StockReleaseResponse>, IStockReleaseService
    {
        private IStockLocationRepository _locationRepository;
        private IProductRepository _productRepository;
        public StockReleaseService(IStockReleaseRepository repository, IMapper mapper, IUnitOfWork uow, IStockLocationRepository locationRepository, IProductRepository producRepository)
            : base(repository, mapper, uow)
        {
            _locationRepository = locationRepository;
            _productRepository = producRepository;
        }
    }
}
