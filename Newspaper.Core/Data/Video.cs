using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Video
    {
        public decimal Id { get; set; }
        public string Videopath { get; set; }
        public decimal? Pageid { get; set; }

        public virtual Page Page { get; set; }
    }
}
