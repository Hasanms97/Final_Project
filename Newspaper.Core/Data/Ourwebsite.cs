using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Ourwebsite
    {
        public Ourwebsite()
        {
            Contactusmessages = new HashSet<Contactusmessage>();
            Pages = new HashSet<Page>();
        }

        public decimal Id { get; set; }
        public string Websitename { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
        public string Phonenumber { get; set; }
        public string Mappath { get; set; }
        public string Linkfacebook { get; set; }
        public string Linkinstagram { get; set; }
        public string Linktwitter { get; set; }
        public string Linklinkedin { get; set; }
        public string Copyright { get; set; }
        public string Logopath { get; set; }
        public decimal? Costhostanddomainperyear { get; set; }

        public virtual ICollection<Contactusmessage> Contactusmessages { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
