using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service
{
    public class SmsService
    {
        public static void SendSMS(string tel, string text, string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create("http://api.rocketsms.by/simple/send?username=" + username + "&password=" + password + "&phone=" + Uri.EscapeUriString(tel) + "&text=" + Uri.EscapeUriString(text));
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(reader))
                    {
                        Deser deser = new Deser();
                        var serializer = new Newtonsoft.Json.JsonSerializer();
                        //var aa = serializer.Deserialize(jsonTextReader);
                        deser = serializer.Deserialize<Deser>(jsonTextReader);
                        Deser.Print(deser);
                        //Console.WriteLine(aa);
                        //Console.WriteLine(aa.ToString());
                        Console.ReadKey();
                    }
                }
            }
            response.Close();


            /*try
            {
                using (WebResponse response = request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                        Console.WriteLine(streamReader.ReadToEnd());
                    return false;
                }
            }*/
        }
    }

    public class Deser
    {
        public int Id { get; set; }
        public string Status { get; set; }
        //public Cost Cost { get; set; }
        //public int Credits { get; set; }
        //public decimal Money { get; set; }
        //public decimal money { get; set; }
        //public int countMessage = 0;
        //public double money = 0;

        public static void Print(Deser deser)
        {
            Console.WriteLine(deser.Id);
            Console.WriteLine(deser.Status);
            //Console.WriteLine(deser.Credits);
            //Console.WriteLine(deser.Money);
            //Console.WriteLine(deser.money);
            //Console.WriteLine(deser.cost[1]);
        }
    }
}
