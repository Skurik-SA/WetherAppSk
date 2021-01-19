using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Weather3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Load_Func();

            PageDown.TranslationY = 1000;
        }

        public async void Load_Func()
        {
            //WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=London&appid=2750decbcac68a9ed2dc17e77992fb87");

            //request.Method = "POST";

            //request.ContentType = "application/x-www-urlencoded";

            //WebResponse response = await request.GetResponseAsync();

            //string answer = string.Empty;

            //using (Stream s = response.GetResponseStream())
            //{
            //    using (StreamReader reader = new StreamReader(s))
            //    {
            //        answer = await reader.ReadToEndAsync();
            //    }
            //}

            //response.Close();

            //editor_sd.Text = answer;


            //string url = "http://api.openweathermap.org/data/2.5/weather?q=Vladivostok&units=metric&appid=2750decbcac68a9ed2dc17e77992fb87&lang=ru";

            string url = "http://api.openweathermap.org/data/2.5/forecast?q=Vladivostok&units=metric&appid=2750decbcac68a9ed2dc17e77992fb87&lang=ru";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = await streamReader.ReadToEndAsync();
                pressure.Text = response.ToString();
                Console.WriteLine(response.ToString());
                Console.ReadLine();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            //city.Text = ($"{weatherResponse.name}").ToString();
            //minTemp.Text = ($"L: {weatherResponse.main.temp_min}°").ToString();
            //maxTemp.Text = ($"H: {weatherResponse.main.temp_max}°").ToString();
            //temp.Text = ($"{ weatherResponse.main.temp}").ToString();
            //pressure.Text = ($"Pressure: {(int)weatherResponse.main.pressure}").ToString();
            //weather.Text = (weatherResponse.weather[0].main).ToString();
            //DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)weatherResponse.dt);
            //dt.Text = dateTimeOffset.ToString();
            //dirwind.Text = ($"{weatherResponse.wind.deg}").ToString();
            //speedwind.Text = ($"{weatherResponse.wind.speed} m/s").ToString();
            //hum.Text = ($"{weatherResponse.main.humidity} %").ToString();

            town.Text = ($"{weatherResponse.city.name}").ToString();
            minTemp.Text = ($"L: {(int)weatherResponse.list[0].main.temp_min}°  ").ToString();
            maxTemp.Text = ($"  H: {(int)weatherResponse.list[0].main.temp_max}°").ToString();
            temp.Text = ($"{(int)weatherResponse.list[0].main.temp}").ToString();
            pressure.Text = ($"Pressure: {(int)(weatherResponse.list[0].main.pressure / 1.3332239)}").ToString();
            weather.Text = (weatherResponse.list[0].weather[0].description).ToString();
            desrp_weather_icon.Source = "picture" + weatherResponse.list[0].weather[0].icon + ".png";
            //DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)weatherResponse.dt);

            string dtweek = DayWeek(weatherResponse.list[0].dt_txt.ToString().Substring(0, 4), weatherResponse.list[0].dt_txt.ToString().Substring(5, 2), weatherResponse.list[0].dt_txt.ToString().Substring(8, 2)).Substring(0,3);
            string dtmonth = WhicMonthYear(MonthYear(weatherResponse.list[0].dt_txt.ToString().Substring(0, 4), weatherResponse.list[0].dt_txt.ToString().Substring(5, 2), weatherResponse.list[0].dt_txt.ToString().Substring(8, 2)));
            dt.Text = dtweek + " " + weatherResponse.list[0].dt_txt.ToString().Substring(8, 2) + " " + dtmonth + " " + weatherResponse.list[0].dt_txt.ToString().Substring(0, 4);

            dirwind.Text = ($"{weatherResponse.list[0].wind.deg}").ToString();
            speedwind.Text = ($"{weatherResponse.list[0].wind.speed} m/s").ToString();
            hum.Text = ($"{weatherResponse.list[0].main.humidity} %").ToString();


            string[] year_we = new string[5];
            string[] month_we = new string[5];
            string[] date_we = new string[5];

            for (int i = 7, j = 0; j < 5; i += 8, j++)
            {
                year_we[j] = weatherResponse.list[i].dt_txt.ToString().Substring(0, 4);
                month_we[j] = weatherResponse.list[i].dt_txt.ToString().Substring(5, 2);
                date_we[j] = weatherResponse.list[i].dt_txt.ToString().Substring(8, 2);
            }

            //day_1.Text = ($"{weatherResponse.list[7].dt_txt}").ToString().Substring(0, 11);

            //string imageUrl = "http://openweathermap.org/img/wn/10d@2x.png";

            //System.Net.WebRequest reqIm = default(System.Net.WebRequest);

            //reqIm = WebRequest.Create(imageUrl);

            //reqIm.Timeout = int.MaxValue;

            //reqIm.Method = "GET";

            //WebResponse respIm = default(WebResponse);
            //respIm = await reqIm.GetResponseAsync();

            //MemoryStream ms = new MemoryStream();

            //respIm.GetResponseStream().CopyTo(ms);
            //byte[] imageData = ms.ToArray();

            //Bitmap


            day_1.Text = DayWeek(year_we[0], month_we[0], date_we[0]);
            day_2.Text = DayWeek(year_we[1], month_we[1], date_we[1]);
            day_3.Text = DayWeek(year_we[2], month_we[2], date_we[2]);
            day_4.Text = DayWeek(year_we[3], month_we[3], date_we[3]);
            day_5.Text = DayWeek(year_we[4], month_we[4], date_we[4]);
            wether_icon_1.Source = "picture" + weatherResponse.list[7].weather[0].icon + ".png";
            wether_icon_2.Source = "picture" + weatherResponse.list[15].weather[0].icon + ".png";
            wether_icon_3.Source = "picture" + weatherResponse.list[23].weather[0].icon + ".png";
            wether_icon_4.Source = "picture" + weatherResponse.list[31].weather[0].icon + ".png";
            wether_icon_5.Source = "picture" + weatherResponse.list[39].weather[0].icon + ".png";
            //day_temp_1.Text = ($"{(int)weatherResponse.list[3].main.temp_max}").ToString();
            //day_temp_2.Text = ($"{(int)weatherResponse.list[11].main.temp_max}").ToString();
            //day_temp_3.Text = ($"{(int)weatherResponse.list[19].main.temp_max}").ToString();
            //day_temp_4.Text = ($"{(int)weatherResponse.list[31].main.temp_max}").ToString();
            //day_temp_5.Text = ($"{(int)weatherResponse.list[35].main.temp_max}").ToString();
            //night_temp_1.Text = ($"{(int)weatherResponse.list[7].main.temp_min}").ToString();
            //night_temp_2.Text = ($"{(int)weatherResponse.list[15].main.temp_min}").ToString();
            //night_temp_3.Text = ($"{(int)weatherResponse.list[23].main.temp_min}").ToString();
            //night_temp_4.Text = ($"{(int)weatherResponse.list[34].main.temp_min}").ToString();
            //night_temp_5.Text = ($"{(int)weatherResponse.list[39].main.temp_min}").ToString();
            day_temp_1.Text = max_DayAndNight(((int)weatherResponse.list[3].main.temp_max).ToString(), ((int)weatherResponse.list[7].main.temp_max).ToString());
            day_temp_2.Text = max_DayAndNight(((int)weatherResponse.list[11].main.temp_max).ToString(), ((int)weatherResponse.list[15].main.temp_max).ToString());
            day_temp_3.Text = max_DayAndNight(((int)weatherResponse.list[19].main.temp_max).ToString(), ((int)weatherResponse.list[23].main.temp_max).ToString());
            day_temp_4.Text = max_DayAndNight(((int)weatherResponse.list[31].main.temp_max).ToString(), ((int)weatherResponse.list[34].main.temp_max).ToString());
            day_temp_5.Text = max_DayAndNight(((int)weatherResponse.list[35].main.temp_max).ToString(), ((int)weatherResponse.list[39].main.temp_max).ToString());
            night_temp_1.Text = min_DayAndNight(((int)weatherResponse.list[3].main.temp_max).ToString(), ((int)weatherResponse.list[7].main.temp_max).ToString());
            night_temp_2.Text = min_DayAndNight(((int)weatherResponse.list[11].main.temp_max).ToString(), ((int)weatherResponse.list[15].main.temp_max).ToString());
            night_temp_3.Text = min_DayAndNight(((int)weatherResponse.list[19].main.temp_max).ToString(), ((int)weatherResponse.list[23].main.temp_max).ToString());
            night_temp_4.Text = min_DayAndNight(((int)weatherResponse.list[31].main.temp_max).ToString(), ((int)weatherResponse.list[34].main.temp_max).ToString());
            night_temp_5.Text = min_DayAndNight(((int)weatherResponse.list[35].main.temp_max).ToString(), ((int)weatherResponse.list[39].main.temp_max).ToString());

            string min_DayAndNight(string d, string n)
            {
                int temp1 = Convert.ToInt32(d);
                int temp2 = Convert.ToInt32(n);

                if (temp1 < temp2)
                {
                    return temp1.ToString();
                }
                else
                {
                    return temp2.ToString();
                }

            }

            string max_DayAndNight(string d, string n)
            {
                int temp1 = Convert.ToInt32(d);
                int temp2 = Convert.ToInt32(n);

                if (temp1 < temp2)
                {
                    return temp2.ToString();
                }
                else
                {
                    return temp1.ToString();
                }

            }
        }
        



        public string DayWeek(string Y, string M, string D)
        {

            DateTime dt = new DateTime(Convert.ToInt32(Y), Convert.ToInt32(M), Convert.ToInt32(D));

            return dt.DayOfWeek.ToString();
        }
        
        public string MonthYear(string Y, string M, string D)
        {
            DateTime dt = new DateTime(Convert.ToInt32(Y), Convert.ToInt32(M), Convert.ToInt32(D));

            return dt.Month.ToString();
        }

        public string WhicMonthYear(string M)
        {
            switch (M)
            {
                case "1":
                    {
                        M = "January";
                        return M;
                    }
                case "2":
                    {
                        M = "February";
                        return M;
                    }
                case "3":
                    {
                        M = "March";
                        return M;
                    }
                case "4":
                    {
                        M = "April";
                        return M;
                    }
                case "5":
                    {
                        M = "May";
                        return M;
                    }
                case "6":
                    {
                        M = "June";
                        return M;
                    }
                case "7":
                    {
                        M = "July";
                        return M;
                    }
                case "8":
                    {
                        M = "August";
                        return M;
                    }
                case "9":
                    {
                        M = "Septemper";
                        return M;
                    }
                case "10":
                    {
                        M = "October";
                        return M;
                    }
                case "11":
                    {
                        M = "November";
                        return M;
                    }
                case "12":
                    {
                        M = "December";
                        return M;
                    }
                default: return M;

            } 
        }


        async void UpBlue_Tapped(object sender, System.EventArgs e)
        {
            await PageDown.TranslateTo(0, 260, 500, Easing.SinIn);
        }

        async void DownWhite_Tapped(object sender, System.EventArgs e)
        {
            await PageDown.TranslateTo(0, 600, 500, Easing.SinIn);
        }
    }
}