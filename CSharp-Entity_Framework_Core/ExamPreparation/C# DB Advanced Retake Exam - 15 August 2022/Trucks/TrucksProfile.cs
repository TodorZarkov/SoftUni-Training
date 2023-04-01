namespace Trucks
{
    using AutoMapper;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            CreateMap<DespatcherDtoImport, Despatcher>()
                .ForMember(d => d.Trucks,
                    cfg => cfg.Ignore());

            CreateMap<TruckDtoImport, Truck>()
                .ForMember(d => d.CategoryType,
                    cfg => cfg.MapFrom(s => (CategoryType)s.CategoryType))
                .ForMember(d => d.MakeType,
                    cfg => cfg.MapFrom(s => (MakeType)s.MakeType));

            CreateMap<ClientDtoImport, Client>();
        }
    }
}
