using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Page
    {
        public Page()
        {
            Contents = new HashSet<Content>();
            Images = new HashSet<Image>();
            Videos = new HashSet<Video>();
        }

        public decimal Id { get; set; }
        public string Pagename { get; set; }
        public decimal? Websiteid { get; set; }

        public virtual Ourwebsite Website { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
