namespace CarDealer;

using AutoMapper;

public class Utils
{
    public IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(c =>
            c.AddProfile<CarDealerProfile>()));
    }

    
}
