namespace Footballers.DataProcessor;

using Castle.Core.Internal;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using System.Globalization;

public static class MapOrIgnore
{
    private static string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};
    public static Coach? Coach(CoachDtoImport? coachDto)
    {
        if (coachDto == null)
        {
            return null;
        }
        if (string.IsNullOrEmpty(coachDto.Name) 
            || coachDto.Name.Length < 2
            || coachDto.Name.Length > 40)
        {
            return null;
        }

        if (string.IsNullOrEmpty(coachDto.Nationality))
        {
            return null;
        }

        return new Coach
        {
            Name = coachDto.Name,
            Nationality = coachDto.Nationality
        };
    }

    public static Footballer? Footballer(FootballerDtoImport? footballerDto)
    {
        //name validate
        if (footballerDto == null)
        {
            return null;
        }
        if (string.IsNullOrEmpty(footballerDto.Name)
            || footballerDto.Name.Length < 2
            || footballerDto.Name.Length > 40)
        {
            return null;
        }

        //dates validate
        if (string.IsNullOrEmpty(footballerDto.ContractStartDate)
            || string.IsNullOrEmpty(footballerDto.ContractEndDate))
        {
            return null;
        }
        DateTime startDate;
        DateTime endDate;
        if (!DateTime.TryParseExact(footballerDto.ContractStartDate, formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out startDate)
            )
        {
            return null;
        }
        if (!DateTime.TryParseExact(footballerDto.ContractEndDate, formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out endDate)
            )
        {
            return null;
        }
        if (startDate > endDate)
        {
            return null;
        }

        //position and best skills validate 
        int position;
        int bestSkill; 
        if (string.IsNullOrEmpty(footballerDto.PositionType) 
            || string.IsNullOrEmpty(footballerDto.BestSkillType)
            || !int.TryParse(footballerDto.PositionType, out position)
            || !int.TryParse(footballerDto.BestSkillType, out bestSkill)
            )
        {
            return null;
        }
        PositionType positionType = (PositionType)position;
        BestSkillType bestSkillType = (BestSkillType)bestSkill;
        if (!Enum.IsDefined<PositionType>(positionType)
            || !Enum.IsDefined<BestSkillType>(bestSkillType)
            )
        {
            return null;
        }


        return new Footballer
        {
            Name = footballerDto.Name,
            ContractStartDate = startDate,
            ContractEndDate = endDate,
            BestSkillType = bestSkillType,
            PositionType = positionType
        };
    }
}
