namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using Newtonsoft.Json;

    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            Utils utils = new Utils();
            StringBuilder sb = new StringBuilder();
            IMapper mapper = utils.CreateMapper();

            var deserializedCreators = utils.XmlDeserialize<CreatorDtoImport[]>(xmlString, "Creators");

            foreach (var deserializedCreator in deserializedCreators)
            {
                int boardgamesCount = 0;
                if (!IsValid(deserializedCreator))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = mapper.Map<Creator>(deserializedCreator);
                foreach (var deserializedBoardgame in deserializedCreator.Boardgames)
                {
                    if (!IsValid(deserializedBoardgame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = mapper.Map<Boardgame>(deserializedBoardgame);
                    creator.Boardgames.Add(boardgame);
                    boardgamesCount++;
                }

                context.Creators.Add(creator);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedCreator, 
                    creator.FirstName, 
                    creator.LastName, 
                    boardgamesCount));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            Utils utils = new Utils();
            IMapper mapper = utils.CreateMapper();

            var deserializedSellers = JsonConvert.DeserializeObject<SellerDtoImport[]>(jsonString);
            var validBoardgameIds = context.Boardgames.Select(b => b.Id).ToHashSet();

            foreach (var deserializedSeller in deserializedSellers)
            {
                int bordgamesCount = 0;
                if (!IsValid(deserializedSeller))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = mapper.Map<Seller>(deserializedSeller);
                foreach (var deserializedId in deserializedSeller.Boardgames)
                {
                    if (!validBoardgameIds.Contains(deserializedId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller();
                    boardgameSeller.BoardgameId = deserializedId;
                    seller.BoardgamesSellers.Add(boardgameSeller);
                    bordgamesCount++;
                }

                context.Sellers.Add(seller);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedSeller,
                    seller.Name, bordgamesCount));
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
