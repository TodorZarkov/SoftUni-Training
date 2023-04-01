namespace Boardgames
{
    using AutoMapper;

    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.DataProcessor.ImportDto;

    public class BoardgamesProfile : Profile
    {
        // DO NOT CHANGE OR RENAME THIS CLASS!
        
        public BoardgamesProfile()
        {
            //creators
            CreateMap<CreatorDtoImport, Creator>()
                .ForMember(s => s.Boardgames,
                    cfg => cfg.Ignore());
            CreateMap<Creator, CreatorDtoExport>()
                .ForMember(d => d.CreatorName,
                    opt => opt.MapFrom(s => string.Join(" ",s.FirstName,s.LastName)))
                .ForMember(d => d.Boardgames,
                    opt => opt.MapFrom(s => s.Boardgames.OrderBy(b => b.Name)))
                .ForMember(d => d.BoardgamesCount,
                    opt => opt.MapFrom(s => s.Boardgames.Count));

            //boardgames
            CreateMap<BoardgameDtoImport, Boardgame>()
                .ForMember(d => d.CategoryType,
                    cfg => cfg.MapFrom(s => (CategoryType)s.CategoryType));

            CreateMap<Boardgame, BoardgameDtoExport>();

            //sellers
            CreateMap<SellerDtoImport, Seller>();
        }
    }
}