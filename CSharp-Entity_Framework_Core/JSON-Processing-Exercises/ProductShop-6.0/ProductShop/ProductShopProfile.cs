namespace ProductShop;

using AutoMapper;
using ProductShop.Dto.Export;
using ProductShop.Dto.Import;
using ProductShop.Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        //User
        CreateMap<UserDtoImport, User>();

        //Product
        CreateMap<ProductDtoImport, Product>();
        CreateMap<Product, ProductDtoExport>()
            .ForMember(d => d.Seller,
                opt => opt.MapFrom(s => s.Seller.FirstName + " " + s.Seller.LastName));

        //Category
        CreateMap<CategoryDtoImport, Category>();

        //CategoryProduct
        CreateMap<CategoryProductDtoImport, CategoryProduct>();
    }
}
