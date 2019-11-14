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

            string pages = "https://swapi.co/api/planets/?page=1";


            while (pages != "")
            {
                JObject planetList = CallRestMethod(pages);

                JArray planets = (JArray)planetList["results"];
                foreach (JObject planet in planets)
                {
                    Console.WriteLine("Planet: " + planet["name"] + "\n");
                    JArray films = (JArray)planet["films"];

                    Console.WriteLine("Film(s): \n");
                    if (films.HasValues)
                    {
                        foreach (JValue film in films)
                        {
                            Console.WriteLine(CallRestMethod(film.ToString())["title"] + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Films");

                    }
                    
                }

                Console.WriteLine();
                pages = planetList["next"].ToString();
            }
            Console.ReadLine();
        }

        static JObject CallRestMethod(string uri)
        {
            try
            {
                // Create a web request for the given uri
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));

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
                
                return JObject.Parse("{'Error':'Something went wrong'}");
            }
        }
    }

}

