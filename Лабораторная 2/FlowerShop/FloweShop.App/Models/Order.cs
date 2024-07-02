using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloweShop.App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
