using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Models
{
    public class AuthenticatedUser
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
