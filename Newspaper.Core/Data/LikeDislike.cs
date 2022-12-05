using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class LikeDislike
    {
        public decimal Id { get; set; }
        public string Type { get; set; }
        public DateTime? DateLikedislike { get; set; }
        public decimal? Newsid { get; set; }
        public decimal? Userid { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
