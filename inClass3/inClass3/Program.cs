using System;
using System.Net;

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
            }
            catch (Exception e)
            {

            }
    }
}
