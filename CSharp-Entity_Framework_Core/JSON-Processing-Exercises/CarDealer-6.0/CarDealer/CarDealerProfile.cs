namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //supplier
        CreateMap<SupplierDtoImport, Supplier>();

        //parts
        CreateMap<PartDtoImport, Part>();

        //customers
        CreateMap<CustomerDtoImport, Customer>();
    }
}
