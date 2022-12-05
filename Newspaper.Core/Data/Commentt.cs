using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Commentt
    {
        public Commentt()
        {
            Replycommentts = new HashSet<Replycommentt>();
        }

        public decimal Id { get; set; }
        public string Text { get; set; }
        public DateTime? DateComment { get; set; }
        public decimal? Newsid { get; set; }
        public decimal? Userid { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Replycommentt> Replycommentts { get; set; }
    }
}
