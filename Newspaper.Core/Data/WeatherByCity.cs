using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Data
{
    public class Main
    {
        public string temp { get; set; }
        public string humidity { get; set; }
    }
    public class Wind
    {
        public string speed { get; set; }
    }



    public class WeatherByCity
    {
        public Main main { get; set; }

        public Wind wind { get; set; }

        public string timezone { get; set; }
        public string name { get; set; }
    }
}
