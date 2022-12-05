using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Contactusmessage
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Respondadmin { get; set; }
        public decimal? Websiteid { get; set; }
        public string Email { get; set; }

        public virtual Ourwebsite Website { get; set; }
    }
}
