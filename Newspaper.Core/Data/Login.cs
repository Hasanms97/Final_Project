using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Login
    {
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
