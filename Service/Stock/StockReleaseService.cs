﻿using AutoMapper;
using Domain.Entities.Auth;
using Domain.Entities.Product;
using Domain.Entities.Stock;
using Domain.Enum;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Product;
using Domain.Interface.Repository.Stock;
using Domain.Interface.Service.Stock;
using Domain.Model.Stock;
using Service.Common;
using Util.Helpers;

namespace Service.Stock
{
    public class StockReleaseService : BaseService<StockReleaseEntity, StockReleaseRequest, StockReleaseResponse>, IStockReleaseService
    {
        private IStockLocationRepository _locationRepository;
        private IProductRepository _productRepository;
        private IStockReleaseRepository _releaseRepository;
        private IStockBalanceRepository _balanceRepository;
        public StockReleaseService(IStockReleaseRepository repository, IMapper mapper, IUnitOfWork uow, IStockLocationRepository locationRepository, IProductRepository producRepository, IStockBalanceRepository stockBalanceRepository, IStockReleaseRepository releaseRepository)
            : base(repository, mapper, uow)
        {
            _locationRepository = locationRepository;
            _productRepository = producRepository;
            _releaseRepository = releaseRepository;
            _balanceRepository = stockBalanceRepository;
        }

        public override async Task<StockReleaseResponse> Create(StockReleaseRequest request)
        {
            try
            {

                
                _uow.Commit();
                return _mapper.Map<StockReleaseResponse>(request);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }

        public async Task<StockBalanceEntity> GetBalanceByProductInfo(int productId, int locationId)
        {
            var balance = await _balanceRepository.GetBalanceByProductInfo(productId, locationId);

            return balance;
        }

        public async Task StockProcessor(ProductEntity product, EReleaseFlow flow, decimal Amount, int StockReleaseId, User user)
        {
            try
            {
                var balance = await GetBalanceByProductInfo((int)product.Id, (int)product.StockLocationId);
                var currentBalance = balance.Balance ?? 0;
                var nextBalance = flow == EReleaseFlow.INFLOW ? currentBalance + Amount : currentBalance - Amount;


                var stockRelease = new StockReleaseEntity()
                {
                    Title = EnumHelper.GetDescription(EStockReleaseType.ADJUST),
                    PreviousBalance = currentBalance,
                    QuantityReleased = Amount,
                    NextBalance = nextBalance,
                    ProductId = product.Id,
                    Product = product,
                    StockReleaseType = EStockReleaseType.ADJUST,
                    Status = EStockReleaseStatus.RELEASED,
                    StockLocationId = product.StockLocationId,
                    StockLocation = product.StockLocation,
                    StockReleaseId = StockReleaseId,
                    UserId = user.Id,
                    User = user,
                    Flow = flow,


                };



                var stockBalance = balance;

                stockBalance.Balance = nextBalance;
                stockBalance.ProductId = product.Id;
                stockBalance.Product = product;
                stockBalance.StockLocationId = product.StockLocationId;
                stockBalance.StockLocation = product.StockLocation;


                await _releaseRepository.Create(stockRelease);

                if (stockBalance.Id > 0)
                {
                    await _balanceRepository.Update(stockBalance);
                }

                else
                {
                    await _balanceRepository.Create(stockBalance);
                }

                _uow.Commit();
            }
            catch (Exception ex) {
                _uow.Rollback();
            }
        }
    }
}
