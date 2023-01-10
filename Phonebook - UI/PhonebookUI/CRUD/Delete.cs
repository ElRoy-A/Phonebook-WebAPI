using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookUI.CRUD
{
    internal class Delete
    {
        internal void DeleteContact()
        {
            int id = DeleteMenu();

            RestClient client = new("https://localhost:5001/");

            RestRequest request = new($"api/Phonebook/{id}", Method.Delete);
            
            Task<RestResponse> response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("\nContact deleted...\n");
            }
        }

        internal int DeleteMenu()
        {
            Console.Clear();

            Read read = new();
            read.GetContactId();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Delete Contact Entry");
            Console.WriteLine("-------------------------");

            int id = Menu.GetId();

            return id;
        }
    }
}
