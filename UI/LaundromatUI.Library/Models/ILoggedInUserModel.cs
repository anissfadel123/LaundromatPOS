using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {

        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string UserName { get; set; }
        DateTime CreatedDate { get; set; }
        string Token { get; set; }
        void ResetUserModel();
    }
}
