using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Newsphoto
    {
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public decimal? Newsid { get; set; }

        public virtual News News { get; set; }
    }
}
