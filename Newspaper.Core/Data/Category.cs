using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Favoritenews = new HashSet<Favoritenews>();
            News = new HashSet<News>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Imagepath { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Favoritenews> Favoritenews { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
