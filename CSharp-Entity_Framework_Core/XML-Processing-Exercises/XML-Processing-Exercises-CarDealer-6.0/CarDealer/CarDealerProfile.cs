using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Security.Cryptography.X509Certificates;

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
        CreateMap<Car, CarWithDiscount>();

        //customers
        CreateMap<CustomerDtoImport, Customer>();
        CreateMap<Customer, CustomerWithSalesDtoExportII>()
            .ForMember(des => des.CarsBought,
                opt => opt.MapFrom(s => s.Sales.Count))
            .ForMember(d => d.TotalPrice,
                opt => opt.MapFrom(src => src.Sales
                .Select(s => s.Car.PartsCars
                    .Select(pc => pc.Part))
                .SelectMany(x => x)
                .Sum(p => p.Price) * (1m - (src.IsYoungDriver?0.05m:0m)) 
                ));
            
        

        //sales
        CreateMap<SaleDtoImport, Sale>()
            .ForMember(d => d.CarId,
                opt => opt.MapFrom(s => s.CarId.Value));
        CreateMap<Sale, SaleWithAndWithoutDiscountDtoExport>()
            .ForMember(d => d.Price,
                opt => opt.MapFrom(src => src.Car.PartsCars
                    .Select(pc => pc.Part).Sum(p => p.Price)))
            .ForMember(d => d.PriceWithDiscount,
                opt => opt.MapFrom(src => 
                (
                    src.Car.PartsCars
                    .Select(pc => pc.Part)
                    .Sum(p => p.Price) * (1 - src.Discount/100)
                 )
                 .ToString("G29")
              ));
    }
}
