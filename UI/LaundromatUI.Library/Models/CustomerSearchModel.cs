using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    //public record CustomerSearchModel (int Id, string FullnameWithId);

    public record CustomerSearchModel
    {
        public int Id { get; set; }
        public string FullnameWithId { get; set; }

        public override string ToString()
        {
            return FullnameWithId;
        }
    }

}
