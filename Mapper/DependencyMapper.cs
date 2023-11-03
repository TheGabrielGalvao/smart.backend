using AutoMapper;
using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Entities.Fiancial;
using Domain.Entities.Product;
using Domain.Entities.Stock;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Repository.Product;
using Domain.Interface.Service;
using Domain.Interface.Service.Product;
using Domain.Model.Auth;
using Domain.Model.Common;
using Domain.Model.Contact;
using Domain.Model.Financial;
using Domain.Model.Product;
using Domain.Model.Stock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repository;
using Repository.Auth;
using Repository.Common;
using Repository.Financial;
using Repository.Product;
using Service;
using Service.Auth;
using Service.Financial;
using Service.Product;

namespace Mapper
{
    public class DependencyMapper
    {
        public static void MapDependenceInjection(IServiceCollection services, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            #region Repository
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IFinancialReleaseRepository, FinancialReleaseRepository>();
            services.AddScoped<IFinancialReleaseTypeRepository, FinancialReleaseTypeRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            services.AddScoped<IAuthRepository>(provider =>
            {
                var autenticacaoUrl = configuration["AuthenticationServiceUrl"];

                return new AuthRepository(autenticacaoUrl, configuration, jwtSettings);
            });



            #endregion

            #region Service
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IFinancialReleaseService, FinancialReleaseService>();
            services.AddTransient<IFinancialReleaseTypeService, FinancialReleaseTypeService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductService, ProductService>();

            #endregion
        }


        #region Entity
        public static IMapper Configure()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserProfileResponse>();
                cfg.CreateMap<UserProfileResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<UserProfileRequest, UserProfile>();

                cfg.CreateMap<User, UserResponse>()
                .ForMember(x => x.ProfileUuid, opt => opt.MapFrom(o => o.Profile.Uuid));
                cfg.CreateMap<UserRequest, User>();
                
                cfg.CreateMap<Contact, ContactResponse>();
                cfg.CreateMap<ContactRequest, Contact>();

                cfg.CreateMap<FinancialRelease, FinancialReleaseResponse>()
                .ForMember(x => x.FinancialReleaseTypeUuid, o => o.MapFrom(src => src.FinancialReleaseType.Uuid))
                .ForMember(x => x.UserUuid, o => o.MapFrom(src => src.User.Uuid))
                .ForMember(x => x.ContactUuid, o => o.MapFrom(src => src.Contact.Uuid));
                cfg.CreateMap<FinancialReleaseRequest, FinancialRelease>();

                cfg.CreateMap<FinancialReleaseType, FinancialReleaseTypeResponse>();
                cfg.CreateMap<FinancialReleaseTypeRequest, FinancialReleaseType>();

                cfg.CreateMap<FinancialReleaseTypeResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));

                cfg.CreateMap<ProductCategory, ProductCategoryResponse>();
                cfg.CreateMap<ProductCategoryResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<ProductCategoryRequest, ProductCategory>();

                cfg.CreateMap<ProductEntity, ProductResponse>()
                .ForMember(x => x.ProductCategoryUuid, opt => opt.MapFrom(o => o.ProductCategory.Uuid));
                cfg.CreateMap<ProductResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<ProductRequest, ProductEntity>();

                cfg.CreateMap<InventoryAdjustmentEntity, InventoryAdjustmentResponse>();
                cfg.CreateMap<InventoryAdjustmentRequest, InventoryAdjustmentEntity>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
        #endregion

    }
}