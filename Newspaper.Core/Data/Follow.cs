using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Follow
    {
        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Pressmanid { get; set; }

        public virtual User Pressman { get; set; }
        public virtual User User { get; set; }
    }
}
