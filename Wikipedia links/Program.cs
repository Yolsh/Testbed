using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Wikipedia_links
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            PageData("https://en.wikipedia.org/w/api.php", "solar system", "3");
            //Console.WriteLine(result);
            Console.ReadKey();
        }

        static void PageData(string path, string search, string lim)
        {
            if (path[path.Length-1] != '?') path += "?";
            string url = path;
            using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("action", "query"),
                new KeyValuePair<string, string>("format", "json"),
                new KeyValuePair<string, string>("list", "allpages")
            }))
            {
                url += content.ReadAsStringAsync().Result;
            }
            Console.WriteLine(url);
            try
            {
                Console.WriteLine(GetPage(url));
            }
            catch 
            {
            }
        }

        static string GetPage(string path)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "WikiGraph (joshapplebysmith@gmail.com)");

            HttpResponseMessage res = client.GetAsync(path).Result;
            string result = JsonSerializer.Serialize(res.Content);
            if (res.IsSuccessStatusCode) return result;
            throw new Exception(result);
        }
    }
}
