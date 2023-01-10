using Newtonsoft.Json;
using PhonebookUI.Contacts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookUI.CRUD
{
    internal class Update
    {
        internal void UpdateContact()
        {
            int id = UpdateById();
            Contact contact = UpdateMenu();

            RestClient client = new("https://localhost:5001/");

            RestRequest request = new($"api/Phonebook{id}", Method.Put);

            request.AddBody(contact);

            Task<RestResponse> response = client.ExecutePutAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("\nContact updated...\n");
            }
        }

        internal Contact UpdateMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Update Contact Entry");
            Console.WriteLine("---------------------------------");

            Contact contact = new Contact();

            Console.Write("\nFirst Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("\nLast Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("\nPhone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("\nEmail: ");
            contact.Email = Console.ReadLine();

            Console.Write("\nAddress: ");
            contact.Address = Console.ReadLine();

            return contact;
        }

        internal int UpdateById()
        {
            Read read = new Read();

            read.GetContactId();

            int id = Menu.GetId();

            return id;
        }
    }
}
