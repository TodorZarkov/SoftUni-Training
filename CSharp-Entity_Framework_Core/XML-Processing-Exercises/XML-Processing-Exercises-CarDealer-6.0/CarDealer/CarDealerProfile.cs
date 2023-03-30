using AutoMapper;
using CarDealer.DTOs.Export;
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
        CreateMap<Car, CarWithDistanceDtoExport>();

        //customers
        CreateMap<CustomerDtoImport, Customer>();

        //sales
        CreateMap<SaleDtoImport, Sale>()
            .ForMember(d => d.CarId,
                opt => opt.MapFrom(s => s.CarId.Value));
    }
}
