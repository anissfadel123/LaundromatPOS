using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    public class WDFModel
    {
        public static readonly byte ToDoStatus = 0;
        public static readonly byte WashStatus = 1;
        public static readonly byte DryStatus = 2;
        public static readonly byte FoldStatus = 3;
        public static readonly byte CompletedTodayStatus = 4;
        public int Id { get; set; }
        public string CustomerName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
        public  DateTime ReadyBy { get; set; }
        public decimal Total { get; set; }
        public string WashMachine { get; set; }
        public string DryMachine { get; set; }
        public byte Status { get; set; }
        public bool IsPickedUp { get; set; }
        public bool IsPaid { get; set; }
        public string Preferences { get; set; }
        public int Bags { get; } = 1;



        
    }
}
