using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.Models
{
    public class WdfModel
    {
        //public static readonly byte ToDoStatus = 0;
        //public static readonly byte WashStatus = 1;
        //public static readonly byte DryStatus = 2;
        //public static readonly byte FoldStatus = 3;
        //public static readonly byte CompletedTodayStatus = 4;
        //public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int ServiceId { get; set; }
        public string Preferences { get; set; }
        public decimal Total { get; set; }
        public DateTime ReadyBy { get; set; }
        public bool Paid { get; set; }
        public byte Status { get; set; } = 0;
        //public string WashMachine { get; set; }
        //public string DryMachine { get; set; }

    }
}
