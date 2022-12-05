using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Replycommentt
    {
        public decimal Id { get; set; }
        public string Text { get; set; }
        public DateTime? DateReplycomment { get; set; }
        public decimal? Commenttid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Commentt Commentt { get; set; }
        public virtual User User { get; set; }
    }
}
