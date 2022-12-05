using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Favoritenews
    {
        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
