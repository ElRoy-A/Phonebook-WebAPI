using Newtonsoft.Json;
using PhonebookUI.Contacts;
using RestSharp;

namespace PhonebookUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check that the Web API is online before proceeding to the main menu
            RestClient client = new RestClient("https://localhost:5001/");

            RestRequest request = new RestRequest("api/Phonebook");

            Task<RestResponse> response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Menu menu = new Menu();
                menu.MainMenu();
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("!!WEB API IS OFFLINE!!");
                Console.WriteLine("---------------------------");
                Console.WriteLine("\nPlease check that the API running...");
                Console.ReadKey();
            }
        }
    }
}