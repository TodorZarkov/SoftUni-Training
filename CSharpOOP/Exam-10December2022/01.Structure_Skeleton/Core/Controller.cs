namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Utilities;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;

    internal class Controller : IController
    {
        BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;
            IBooth booth = new Booth(id, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == cocktailTypeName);
            if (type == null)
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] sizes = { "Small", "Middle", "Large" };
            if(!sizes.Contains(size))
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail coctail = (ICocktail)Activator.CreateInstance(type, cocktailName,size);
            booth.CocktailMenu.AddModel(coctail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            

            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == delicacyTypeName);
            if(type == null)
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            
            if(booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = (IDelicacy)Activator.CreateInstance(type, delicacyName);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format(OutputMessages.GetBill, $"{bill:F2}"));
            result.Append(string.Format(OutputMessages.BoothIsAvailable, booth.BoothId));
            return result.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            Booth availableBooth = (Booth) booths.Models.
                Where(b => !b.IsReserved && b.Capacity >= countOfPeople).
                OrderBy(b => b.Capacity).
                ThenByDescending(b => b.BoothId).FirstOrDefault();
            if(availableBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooth.IsReserved = true;
            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] data = order.Split("/");
            string itemTypeName = data[0];
            string itemName = data[1];
            int count = int.Parse(data[2]);
            string cocktailSize = null;
            if (data.Length == 4)
            {
                cocktailSize = data[3];
            }


            Type type = Validate.GetIfType(data[0]);
            if(itemTypeName == null)
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if(booth.DelicacyMenu.Models.FirstOrDefault(m=>m.Name == itemName) == null)
            {
                if(cocktailSize == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, type.Name, itemName);
                }
                else if(booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName&& c.Size == cocktailSize) == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }
            }

            if(data.Length == 3)
            {
                IDelicacy delicacy = (IDelicacy)Activator.CreateInstance(type, itemName);
                booth.UpdateCurrentBill(delicacy.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);

            }
            else
            {
                ICocktail cocktail = (ICocktail)Activator.CreateInstance(type, itemName, cocktailSize);
                booth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
            }


        }
    }
}
