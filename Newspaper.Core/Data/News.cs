using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class News
    {
        public News()
        {
            Commentts = new HashSet<Commentt>();
            LikeDislikes = new HashSet<LikeDislike>();
            Newsphotos = new HashSet<Newsphoto>();
            Newsvideos = new HashSet<Newsvideo>();
        }

        public decimal Id { get; set; }
        public string Newstitle { get; set; }
        public string Description { get; set; }
        public DateTime? Newsdate { get; set; }
        public string Country { get; set; }
        public string Checkadmin { get; set; }
        public decimal? UseridPressman { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual User UseridPressmanNavigation { get; set; }
        public virtual ICollection<Commentt> Commentts { get; set; }
        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }
        public virtual ICollection<Newsphoto> Newsphotos { get; set; }
        public virtual ICollection<Newsvideo> Newsvideos { get; set; }

        //FavoriteNewsRepository الموجود ب Method( DisplayFavoriteNewsForUserId )مشان 
        [NotMapped]
        public string Firstname { get; set; }
        [NotMapped]
        public string Lastname { get; set; }
        [NotMapped]
        public string Imagepath { get; set; }
    }
}
