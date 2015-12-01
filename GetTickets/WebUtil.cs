using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetTickets.Properties;
using Newtonsoft.Json.Linq;

namespace GetTickets
{
    public class WebUtil
    {

        public async Task GetResponse(URL url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.Domain);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url.Path);
                    response.EnsureSuccessStatusCode();    // Throw if not a success code.  
                    string content = await response.Content.ReadAsStringAsync();

                    int startIndex = content.IndexOf('{');
                    int endIndex = content.Length - 2;
                    content = content.Substring(startIndex, endIndex - startIndex + 1);

                    JObject jObject = JObject.Parse(content);
                    JObject maps = jObject["data"]["priceMap"] as JObject;
                    List<Flight> list = new List<Flight>();
                    foreach (var map in maps)
                    {
                        string name = map.Key;
                        JToken m = map.Value;
                        Flight f = new Flight()
                        {
                            Name = name,
                            Price = Convert.ToInt32(m["prWithTax"])
                        };
                        list.Add(f);
                    }

                    var list2 = list.OrderBy(f => f.Price);
                    foreach (var flight in list2)
                    {
                        if (flight.Price <= 1300)
                        {
                            System.Media.SystemSounds.Beep.Play();
                            MessageBox.Show("The ticket is coming!!!");
                        }
                        Console.WriteLine(flight.Name + Resources.WebUtil_GetResponse____ + flight.Price);
                    }

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }


    public class Flight
    {
        public string Name { get; set; }

        public int Price { get; set; }
    }

    public class URL
    {
        public string Domain { get; set; }

        public string Path { get; set; }

        public URL(string domain, string path)
        {
            Domain = domain;
            Path = path;
        }
    }
}
