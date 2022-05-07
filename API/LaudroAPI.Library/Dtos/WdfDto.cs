using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroAPI.Library.Dtos
{
    public record WdfDto(int Id, string FirstName, string LastName, int CustomerId, int ServiceId, string Preferences, decimal Total, DateTime ReadyBy, bool IsPaid, byte Status, bool IsPickedUp, string WashMachine, string DryMachine);
    public record CreateWdfDto(int CustomerId, int ServiceId, string Preferences, decimal Total, DateTime ReadyBy,
        bool Paid);
}
