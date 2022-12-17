namespace ChristmasPastryShop.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Utilities;
    using ChristmasPastryShop.Utilities.Factories;
    using ChristmasPastryShop.Utilities.Messages;

    internal class Controller : IController
    {
        private readonly BoothRepository booths;

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
            Assembly assembly = Assembly.GetExecutingAssembly();
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

            ICocktail cocktail;
            try
            {
                cocktail = (ICocktail)Activator.CreateInstance(type, cocktailName, size);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            

            Assembly assembly = Assembly.GetExecutingAssembly();
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

            IDelicacy delicacy;
            try
            {
                delicacy = (IDelicacy)Activator.CreateInstance(type, delicacyName);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
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

            availableBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] data = order.Split("/");

            string itemTypeName = data[0];
            string itemName = data[1];
            int count = int.Parse(data[2]);
            string itemSize = null;

            object[] constructorParams;
            if (data.Length == 4)
            {
                itemSize = data[3];
                constructorParams = new object[2] { itemName, itemSize};
            }
            else
            {
                constructorParams = new object[1] { itemName};
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            object item = Factory.Produce(itemTypeName, constructorParams);
            if (item == null)
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (typeof(ICocktail).IsAssignableFrom(item.GetType()))
            {
                ICocktail coctail = (ICocktail)item;

                if (booth.CocktailMenu.Models.
                    FirstOrDefault(c => c.Name == itemName) == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == itemSize) == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, itemSize, itemName);
                }

                booth.UpdateCurrentBill(coctail.Price * count);
            }
            else //if (typeof(IDelicacy).IsAssignableFrom(item.GetType()))
            {
                IDelicacy delicacy = (IDelicacy)item;
                if (booth.DelicacyMenu.Models.FirstOrDefault(d=>d.Name == itemName) == null)
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * count);
            }

            return String.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
            




        }
    }
}
