namespace ProductShop;

using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        //Users
        CreateMap<UserDtoImport, User>();

        //Products
        CreateMap<ProductDtoImport, Product>();
        CreateMap<Product, ProductDtoExport>()
            .ForMember(d => d.Buyer,
                opt => opt.MapFrom(s => s.BuyerId.HasValue ?
                                        string.Join(" ", s.Buyer.FirstName, s.Buyer.LastName) :
                                        null))
            .ForMember(d => d.Price,
                opt=>opt.MapFrom(s => s.Price.ToString("G29")));

        //Categories
        CreateMap<CategoryDtoImport, Category>();

        //CategoryProducts
        CreateMap<CategoryProductDtoImport, CategoryProduct>();
    }
}
