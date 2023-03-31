namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        { 
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();
            StringBuilder sb = new StringBuilder();

            var deserializedCoaches = utils.XmlDeserialize<CoachDtoImport[]>(xmlString, "Coaches");


            foreach (var deserializedCoach in deserializedCoaches)
            {
                int footballersByCoachCount = 0;
                Coach? coach = MapOrIgnore.Coach(deserializedCoach);
                if (coach == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var footballerDto in deserializedCoach.Footballers)
                {
                    Footballer? footballer = MapOrIgnore.Footballer(footballerDto);
                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    coach.Footballers.Add(footballer);
                    footballersByCoachCount++;
                }
                context.Coaches.Add(coach);
                sb.AppendLine(
                    string.Format(SuccessfullyImportedCoach, coach.Name, footballersByCoachCount));
            }

            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var deserializedTeams = JsonConvert.DeserializeObject<TeamDtoImport[]>(jsonString);

            var validFootballserIds = context.Footballers.Select(f => f.Id);
            foreach (var deserializedTeam in deserializedTeams)
            {
                int footballersCount = 0;
                if (!IsValid(deserializedTeam))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var team = mapper.Map<Team>(deserializedTeam);
                foreach (int footboolerId in deserializedTeam.Footballers)
                {
                    if (!validFootballserIds.Contains(footboolerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    TeamFootballer teamFootballer = new TeamFootballer();
                    teamFootballer.FootballerId = footboolerId;

                    team.TeamsFootballers.Add(teamFootballer);
                    footballersCount++;
                }
                context.Teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, footballersCount));
            }

            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
