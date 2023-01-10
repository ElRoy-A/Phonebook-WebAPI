using Newtonsoft.Json;
using RestSharp;
using PhonebookUI.Contacts;

namespace PhonebookUI.CRUD
{
    internal class Read
    {
        internal void GetContacts()
        {
            RestClient client = new RestClient("https://localhost:5001/");

            RestRequest request = new RestRequest("api/Phonebook", Method.Get);

            Task<RestResponse> response = client.ExecuteGetAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Result.Content;

                List<Contact> deserialized = JsonConvert.DeserializeObject<List<Contact>>(json);

                VisualizePhonebook.ShowTableList(deserialized, "Phonebook");
            }
        }

        internal void GetContact(int id)
        {
            Console.Clear();

            RestClient client = new RestClient("https://localhost:5001/");

            RestRequest request = new RestRequest($"api/Phonebook/{id}", Method.Get);

            Task<RestResponse> response = client.ExecuteGetAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Result.Content;

                Contact deserialized = JsonConvert.DeserializeObject<Contact>(json);

                List<Contact> contact = new List<Contact>();
                contact.Add(deserialized);

                VisualizePhonebook.ShowTableList(contact, "Contact Information");
            }
        }

        internal void GetContactMenu()
        {
            GetContactId();

            int id = Menu.GetId();

            GetContact(id);
        }

        internal void GetContactId()
        {
            RestClient client = new RestClient("https://localhost:5001/");

            RestRequest request = new RestRequest("api/Phonebook", Method.Get);

            Task<RestResponse> response = client.ExecuteGetAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Result.Content;

                List<ContactID> deserialized = JsonConvert.DeserializeObject<List<ContactID>>(json);

                VisualizePhonebook.ShowTableList(deserialized, "Phonebook");
            }
        }
    }
}
