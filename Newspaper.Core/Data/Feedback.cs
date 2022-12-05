using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Feedback
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public decimal? Evaluation { get; set; }
        public string Checkadmin { get; set; }
        public decimal? Userid { get; set; }

        public virtual User User { get; set; }
    }
}
