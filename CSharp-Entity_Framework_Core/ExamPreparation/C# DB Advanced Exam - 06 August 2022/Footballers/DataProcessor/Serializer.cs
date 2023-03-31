namespace Footballers.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Castle.Core.Internal;
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var coaches = context.Coaches
                .Where(c => c.Footballers.Any())
                .ProjectTo<CoachDtoExport>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();


            return utils.XmlSerialize<CoachDtoExport[]>(coaches, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .OrderByDescending
                (t => t.TeamsFootballers.Count(tf => tf.Footballer.ContractStartDate >= date))
                .ThenBy(t => t.Name)
                .Take(5)
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .Select(tf => new
                    {
                        FootballerName = tf.Footballer.Name,
                        ContractStartDate = tf.Footballer.ContractStartDate,//toformat
                        ContractEndDate = tf.Footballer.ContractEndDate,//toformat
                        BestSkillType = tf.Footballer.BestSkillType,
                        PositionType = tf.Footballer.PositionType
                    })
                    .OrderByDescending(f => f.ContractEndDate)
                    .ThenBy(f => f.FootballerName)
                    .ToArray()
                    .Select(f => new
                    {
                        f.FootballerName,
                        ContractStartDate = 
                            f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = 
                            f.ContractEndDate.ToString("d",CultureInfo.InvariantCulture),
                        f.BestSkillType,
                        f.PositionType
                    })
                })
                .ToArray();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = {new StringEnumConverter()},
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(teams, settings);
        }
    }
}
