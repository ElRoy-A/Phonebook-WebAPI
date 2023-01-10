using PhonebookUI.Contacts;
using RestSharp;

namespace PhonebookUI.CRUD
{
    internal class Create
    {
        internal void CreateContact()
        {
            Contact contact = CreateMenu();

            RestClient client = new("https://localhost:5001/");

            RestRequest request = new("api/Phonebook", Method.Post);

            request.AddJsonBody(contact);

            Task<RestResponse> response = client.ExecutePostAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("\nContact created...\n");
            }
        }

        internal Contact CreateMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("New Contact Entry");
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

            return(contact);
        }
    }


}
