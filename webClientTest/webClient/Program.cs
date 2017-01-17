using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using webClient.Models;


namespace webClient
{
    class Program
    {
        static int portNumber;
        static void Main()
        {
            Console.Write("Please enter the port number : ");
            string strPort = Console.ReadLine();
            portNumber = int.Parse(strPort);
            RunAsync().Wait();
        }
        

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format("http://localhost:{0}/", portNumber));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

                // comment this header to stop deletion
                client.DefaultRequestHeaders.Add("secretkey", "secret");

                // HTTP GET
     //           HttpResponseMessage response = await client.GetAsync("api/ApiCSUser/1");
                HttpResponseMessage response = await client.GetAsync("api/ApiCSUser/GetCSUser/1");
                if (response.IsSuccessStatusCode)
                {
                    CSUser csUser = await response.Content.ReadAsAsync<CSUser>();
                    Console.WriteLine("{0}\t{1}\t has the following email: {2} ", csUser.CSUserID, csUser.UserName, csUser.Email);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Getting CS user failure reason : " + response.ReasonPhrase);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();

                var csUser2 = new CSUser();
                Console.Write("Enter a name for the new user : ");
                csUser2.UserName = Console.ReadLine();

                Console.Write("Enter a email for the new user : ");
                csUser2.Email = Console.ReadLine();

                Console.Write("Enter a password for the new user : ");
                csUser2.Password = Console.ReadLine();

                response = await client.PostAsJsonAsync("api/ApiCSUser", csUser2);
                if (response.IsSuccessStatusCode)
                {
                    Uri entityUrl = response.Headers.Location;
                    Console.WriteLine("Successfully added the new user: {0}", entityUrl);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Use the browser to check that we now have a new user with title : {0}", csUser2.UserName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("press c/r to continue...");
                    Console.ReadLine();
                    
                    string localPath = entityUrl.LocalPath;

                    response = await client.DeleteAsync(entityUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Successfully deleted the  user: {0}", localPath);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Use the browser to check that the forum has been deleted", csUser2.UserName);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("User was not deleted. BadRequest is returned when correct secretkey is not provided in header :" + response.ReasonPhrase);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failure reason : " + response.ReasonPhrase);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }

            }
        }

    }
}
