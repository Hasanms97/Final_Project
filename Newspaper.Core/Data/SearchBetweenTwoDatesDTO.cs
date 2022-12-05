using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Data
{
    public class SearchBetweenTwoDatesDTO
    {
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
    }
}
