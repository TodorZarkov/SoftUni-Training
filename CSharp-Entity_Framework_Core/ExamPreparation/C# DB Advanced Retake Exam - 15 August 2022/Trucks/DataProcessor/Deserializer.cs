namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            Utils utils = new Utils();
            StringBuilder sb = new StringBuilder();
            IMapper mapper = utils.CreateMapper();

            var deserializedDespatchers = utils.XmlDeserialize<DespatcherDtoImport[]>(xmlString, "Despatchers");

            
            foreach (var deserializedDespacher in deserializedDespatchers)
            {
                int trucksCount = 0;
                if (!IsValid(deserializedDespacher))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var despatcher = mapper.Map<Despatcher>(deserializedDespacher);

                foreach (var deserializedTruck in deserializedDespacher.Trucks)
                {
                    if (!IsValid(deserializedTruck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var truck = mapper.Map<Truck>(deserializedTruck);
                    despatcher.Trucks.Add(truck);
                    trucksCount++;
                }

                context.Despatchers.Add(despatcher);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedDespatcher, 
                        despatcher.Name, 
                        trucksCount));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            Utils utils = new Utils();
            StringBuilder sb = new StringBuilder();
            IMapper mapper = utils.CreateMapper();

            var deserializedClients = JsonConvert.DeserializeObject<ClientDtoImport[]>(jsonString);

            var validTruckIds = context.Trucks.Select(t => t.Id).ToHashSet();
            foreach (var deserializedClient in deserializedClients)
            {
                int trucksCount = 0;
                if (!IsValid(deserializedClient))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var client = mapper.Map<Client>(deserializedClient);

                foreach (var deserializedTruckId in deserializedClient.Trucks)
                {
                    if (!validTruckIds.Contains(deserializedTruckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    ClientTruck clientTruck = new ClientTruck();
                    clientTruck.TruckId = deserializedTruckId;
                    client.ClientsTrucks.Add(clientTruck);
                    trucksCount++;
                }

                context.Clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, trucksCount));
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