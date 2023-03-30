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
        CreateMap<Supplier, SupplierWthLocalePartsDtoExport>()
            .ForMember(d => d.PartsCount,
                opt => opt.MapFrom(s => s.Parts.Count));

        //parts
        CreateMap<PartDtoImport, Part>();
        CreateMap<Part, PartWithNameAndPriceDtoExport>();

        //cars
        CreateMap<CarDtoImport, Car>()
            .ForMember(d => d.PartsCars,
                opt => opt.MapFrom(s => s.PartIds.Select(pid => new PartCar { PartId = pid.Id })));
        CreateMap<Car, CarWithDistanceDtoExport>();
        CreateMap<Car, CarByMakeDtoExport>();
        CreateMap<Car, CarWithPartsDtoExport>()
            .ForMember(d => d.Parts,
                opt => opt.MapFrom(s => s.PartsCars.Select(pc => pc.Part)
                .OrderByDescending(p => p.Price)
                .ToArray()));

        //customers
        CreateMap<CustomerDtoImport, Customer>();
        

        //sales
        CreateMap<SaleDtoImport, Sale>()
            .ForMember(d => d.CarId,
                opt => opt.MapFrom(s => s.CarId.Value));
    }
}
