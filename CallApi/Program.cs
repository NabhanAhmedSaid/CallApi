using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
namespace CallApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Choice the api you want \n 1.Coffee image \n 2.Cat Fact \n 3.Bitcoin Price \n 4. random activities  \n 5. Data USA");

            int choice = Int32.Parse(Console.ReadLine());
            string apiUrl = "";
            switch (choice)
            {
                case 1:
                    apiUrl = "https://coffee.alexflipnote.dev/random.json";
                    break;
                case 2:
                    apiUrl = "https://catfact.ninja/fact";
                    break;
                case 3:
                    apiUrl = "https://api.coindesk.com/v1/bpi/currentprice.json";
                    break;
                case 4:
                    apiUrl = "https://www.boredapi.com/api/activity";
                    break;
                case 5:
                    apiUrl = "https://datausa.io/api/data?drilldowns=Nation&measures=Population";
                    break ;
                default:
                    break;
            }


           
            var awaiter = CallURL(apiUrl);
            if (awaiter.Result != "")
            {
                // File.WriteAllText(fileOutput, awaiter.Result);
                //Console.WriteLine("HTML Response output to " + fileOutput);
                Console.WriteLine(awaiter.Result);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static async Task<string> CallURL(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}

