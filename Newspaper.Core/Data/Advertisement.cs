using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Advertisement
    {
        public decimal Id { get; set; }
        public string Imagepath { get; set; }
        public string Videopath { get; set; }
        public string Link { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public string Checkadminonads { get; set; }
        public string Checkadmintopay { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Categoryadsid { get; set; }

        public virtual Categoryad Categoryads { get; set; }
        public virtual User User { get; set; }


        //GetAllAdvertisement مشان   
        [NotMapped]
        public string Type { get; set; }
        [NotMapped]
        public decimal? Durationinmonth { get; set; }
        [NotMapped]
        public decimal? Price { get; set; }
    }
}
