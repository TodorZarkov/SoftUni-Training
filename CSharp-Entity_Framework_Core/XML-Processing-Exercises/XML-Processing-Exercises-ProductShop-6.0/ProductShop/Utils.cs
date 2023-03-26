namespace ProductShop;

using AutoMapper;

public class Utils
{
    public static IMapper CreateMapper()
    {
        return new Mapper(
            new MapperConfiguration(c => c.AddProfile<ProductShopProfile>()));
    }


}
