namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.DataProcessor.ImportDto;

    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public class FootballersProfile : Profile
    {
        public FootballersProfile()
        {
            //teams
            CreateMap<TeamDtoImport, Team>();

            //coaches
            CreateMap<Coach, CoachDtoExport>()
                .ForMember(d => d.FootballersCount,
                    opt => opt.MapFrom(s => s.Footballers.Count))
                .ForMember(d => d.Footballers,
                    opt => opt.MapFrom(s => s.Footballers.OrderBy(f => f.Name)));

            //footballers
            CreateMap<Footballer, FootballersDtoExport>();
        }
    }
}
