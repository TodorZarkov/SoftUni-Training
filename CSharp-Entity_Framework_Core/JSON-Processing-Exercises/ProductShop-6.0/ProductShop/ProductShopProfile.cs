namespace ProductShop;

using AutoMapper;
using ProductShop.Dto.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        CreateMap<UserDtoImport, User>();

        CreateMap<ProductDtoImport, Product>();
    }
}
