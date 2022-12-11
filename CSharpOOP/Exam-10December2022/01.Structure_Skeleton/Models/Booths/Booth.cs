namespace ChristmasPastryShop.Models.Booths
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Booth : IBooth
    {
        int boothId;
        int capacity;

        IRepository<IDelicacy> delicacyMenu;
        IRepository<ICocktail> cocktailMenu;
        double currentBill;
        double turnover;
        bool isReserved;

        private Booth()
        {
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }
        public Booth(int boothId, int capacity) : this()
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId
        {
            get => boothId;
            private set
            {
                boothId = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => cocktailMenu;

        public double CurrentBill
        {
            get => currentBill;
            private set
            {
                currentBill = value;
            }
        }

        public double Turnover
        {
            get => turnover;
            private set
            {
                turnover = value;
            }
        }

        public bool IsReserved
        {
            get => isReserved;
            set
            {
                isReserved = value;
            }
        }



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
            string coctailToPrint = string.Join(Environment.NewLine, cocktailMenu.Models.Select(c => $"--{c}"));
            if (coctailToPrint != "")
                sb.AppendLine(coctailToPrint);


            sb.AppendLine($"-Delicacy menu:");
            string delicacyToPrint = string.Join(Environment.NewLine, delicacyMenu.Models.Select(d => $"--{d}"));
            sb.AppendLine(delicacyToPrint);


            return sb.ToString().Trim();
        }
    }
}
