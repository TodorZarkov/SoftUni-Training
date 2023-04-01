namespace Boardgames.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ProjectTo<CreatorDtoExport>(mapper.ConfigurationProvider)
                .ToArray()
                .OrderByDescending(c => c.Boardgames.Count())
                .ThenBy(c => c.CreatorName)
                .ToArray();
                


            return utils.XmlSerialize<CreatorDtoExport[]>(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year &&
                                                            bs.Boardgame.Rating <= rating))
                .OrderByDescending(s => s.BoardgamesSellers
                    .Count(bs => bs.Boardgame.YearPublished >= year &&
                                    bs.Boardgame.Rating <= rating))
                .ThenBy(s => s.Name)
                .Take(5)
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year &&
                                 bs.Boardgame.Rating <= rating)
                    .Select(bs => new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType
                    })
                    .OrderByDescending(g => g.Rating)
                    .ThenBy(g => g.Name)
                    .ToArray()
                })
                .ToArray();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = { new StringEnumConverter() },
                Formatting = Formatting.Indented
            };


            return JsonConvert.SerializeObject(sellers, settings);
        }
    }
}