using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Categoryad
    {
        public Categoryad()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public decimal Id { get; set; }
        public string Type { get; set; }
        public decimal? Durationinmonth { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
