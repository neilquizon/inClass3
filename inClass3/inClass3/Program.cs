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

            const string BASE_URL = "https://swapi.co/api/";
            const string PLANETS = "planets/";
            

            JObject planetList = CallRestMethod(BASE_URL + PLANETS);

            JArray planets = (JArray)planetList["results"];

            foreach (JObject planet in planets)
            {
                Console.WriteLine("Planet: " + planet["name"] + "\n");
                JArray films = (JArray)planet["films"];

                Console.WriteLine("Film(s): \n");

                foreach (JValue film in films)
                {
                    Console.WriteLine(CallRestMethod(film.ToString())["title"] + "\n");
                }
            }

            Console.ReadLine();
        }

        static JObject CallRestMethod(string uri)
        {
            try
            {
                // Create a web request for the given uri
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                // Get the web response from the api
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get a stream to read the reponse
                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                // Read the response and write it to the console
                JObject result = JObject.Parse(responseStream.ReadToEnd());

                // Close the connection to the api and the stream reader
                response.Close();

                responseStream.Close();

                return result;
            }
            catch (Exception e)
            {
                
                return JObject.Parse("Error not in any films");
            }
        }
    }

}

