namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<Tuple<string, string?>> Items { get; set; } = null!; 

        public List<Tuple<string, string?>> Employees { get; set; } = null!; 

    }
}
