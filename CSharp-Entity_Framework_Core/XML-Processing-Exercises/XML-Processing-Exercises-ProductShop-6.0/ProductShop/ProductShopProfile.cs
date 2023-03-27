using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Users
            CreateMap<UserDtoImport, User>();

            //Products
            CreateMap<ProductDtoImport, Product>();

            //Categories
            CreateMap<CategoryDtoImport, Category>();


        }
    }
}
