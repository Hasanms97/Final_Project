using System;
using System.Collections.Generic;

#nullable disable

namespace Newspaper.Core.Data
{
    public partial class Bankvisa
    {
        public decimal Id { get; set; }
        public string Cardnumber { get; set; }
        public string Cardholdername { get; set; }
        public string Cvv { get; set; }
        public DateTime? Expirationdate { get; set; }
        public decimal? Availableamount { get; set; }
    }
}
