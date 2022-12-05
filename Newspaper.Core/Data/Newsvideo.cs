using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Newsvideo
    {
        public decimal Id { get; set; }
        public string Videopath { get; set; }
        public decimal? Newsid { get; set; }

        public virtual News News { get; set; }
    }
}
