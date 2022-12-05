using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Content
    {
        public decimal Id { get; set; }
        public string Text { get; set; }
        public decimal? Pageid { get; set; }

        public virtual Page Page { get; set; }
    }
}
