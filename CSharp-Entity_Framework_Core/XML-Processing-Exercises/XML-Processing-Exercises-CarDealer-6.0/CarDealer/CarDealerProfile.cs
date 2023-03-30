using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //suppliers
        CreateMap<SupplierDtoImport, Supplier>();

        //parts
        CreateMap<PartDtoImport, Part>();

        //cars
        CreateMap<CarDtoImport, Car>()
            .ForMember(d => d.PartsCars,
                opt => opt.MapFrom(s => s.PartIds.Select(pid => new PartCar { PartId = pid.Id })));

        //customers
        CreateMap<CustomerDtoImport, Customer>();
    }
}
