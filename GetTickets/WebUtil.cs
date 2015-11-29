using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetTickets
{
    public class WebUtil
    {
        
        public async void GetResponse(string domain, string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(domain);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();    // Throw if not a success code.  

                    string content = await response.Content.ReadAsStringAsync();
                                      
                    
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
