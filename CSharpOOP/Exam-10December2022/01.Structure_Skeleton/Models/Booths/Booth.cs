namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Linq;
    using System.Text;

    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;

    public class Booth : IBooth
    {
        int capacity;

        private Booth()
        {
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }
        public Booth(int boothId, int capacity) : this()
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }



        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");

            sb.AppendLine($"-Cocktail menu:");
            string coctailToPrint = string.Join(Environment.NewLine, CocktailMenu.Models.Select(c => $"--{c}"));
            if (coctailToPrint != "")
                sb.AppendLine(coctailToPrint);


            sb.AppendLine($"-Delicacy menu:");
            string delicacyToPrint = string.Join(Environment.NewLine, DelicacyMenu.Models.Select(d => $"--{d}"));
            if (delicacyToPrint != "")
                sb.AppendLine(delicacyToPrint);


            return sb.ToString().Trim();
        }
    }
}
