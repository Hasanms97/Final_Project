using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class User
    {
        public User()
        {
            Advertisements = new HashSet<Advertisement>();
            Commentts = new HashSet<Commentt>();
            Favoritenews = new HashSet<Favoritenews>();
            Feedbacks = new HashSet<Feedback>();
            FollowPressmen = new HashSet<Follow>();
            FollowUsers = new HashSet<Follow>();
            LikeDislikes = new HashSet<LikeDislike>();
            Logins = new HashSet<Login>();
            News = new HashSet<News>();
            Replycommentts = new HashSet<Replycommentt>();
        }

        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Country { get; set; }
        public string Phonenumber { get; set; }
        public string Imagepath { get; set; }
        public string Journalistcertificatepath { get; set; }
        public string Description { get; set; }
        public decimal? Salary { get; set; }
        public string Owner { get; set; }
        public string Checkadmin { get; set; }
        public string Emailnotifications { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Commentt> Commentts { get; set; }
        public virtual ICollection<Favoritenews> Favoritenews { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Follow> FollowPressmen { get; set; }
        public virtual ICollection<Follow> FollowUsers { get; set; }
        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Replycommentt> Replycommentts { get; set; }
    }
}
