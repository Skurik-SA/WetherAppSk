using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Weather3
{
    public class WeatherResponse
    {

        public list[] list;

        public city city;

    }

    public class list
    {
        public double dt;

        public main main;

        public weather[] weather;

        public clouds clouds;

        public wind wind;

        public double visibility;

        public double pop;

        public rain rain;

        public sys sys;

        public string dt_txt;


    }

    public class main
    {
        public double temp;

        public double feels_like;

        public double temp_min;

        public double temp_max;

        public double pressure;

        public double sea_level;

        public double grnd_level;

        public double humidity;

        public double temp_kf;
    }

    public class weather
    {
        public int id;

        public string main;

        public string description;

        public string icon;
    }

    public class clouds
    {
        public double all;
    }

    public class wind
    {
        public double speed;

        public double deg;
    }

    public class rain
    {
        public double ps;
    }

    public class sys
    {
        public string pod;
    }

    public class city
    {
        public int id;

        public string name;

        public class coord
        {
            public double lat;

            public double lon;
        }

        public string country;

        public double timezone;

        public double sunrise;

        public double sunset;
    }
}
