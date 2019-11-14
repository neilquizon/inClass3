using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace inClass3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string baseUrl = "https://swapi.co/api/";
            string planets = "planets/";
            string people = "people/";
            try
            {
                Uri uri = new Uri(baseUrl + planets);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                Console.WriteLine(JObject.Parse(responseStream.ReadToEnd()));

            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured. Could not get planets:\n" + e.Message);
            }
            Console.ReadLine();
        }
    }
}

