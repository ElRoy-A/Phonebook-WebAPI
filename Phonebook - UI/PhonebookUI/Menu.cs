using PhonebookUI.CRUD;

namespace PhonebookUI
{
    internal class Menu
    {
        internal void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("Welcome to the Phonebook Application");
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1 - View All Contacts");
            Console.WriteLine("2 - View Contact");
            Console.WriteLine("3 - Create Contact");
            Console.WriteLine("4 - Update Contact");
            Console.WriteLine("5 - Delete Contact");
            Console.WriteLine("0 - Exit Application");

            Console.Write("\nEnter your choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    // View all contacts
                    Read read = new Read();
                    read.GetContacts();
                    ReturnToMenu();
                    break;

                case "2":
                    // View one contact
                    Read readId = new Read();
                    readId.GetContactMenu();
                    ReturnToMenu();
                    break;

                case "3":
                    // Insert new contact
                    Create create = new Create();
                    create.CreateContact();
                    ReturnToMenu();
                    break;

                case "4":
                    // Update a contact
                    Update update = new Update();
                    update.UpdateContact();
                    ReturnToMenu();
                    break;

                case "5":
                    // Delete a contact
                    Delete delete = new Delete();
                    delete.DeleteContact();
                    ReturnToMenu();
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Press any key to try again...");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        internal void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MainMenu();
        }

        internal static int GetId()
        {
            Console.Write("\nChoose contact ID: ");
            string userinputId = Console.ReadLine().Trim();

            while (!Validation.IsIdValid(userinputId))
            {
                Console.WriteLine("Invalid ID");
                Console.Write("Choose contact ID: ");
                userinputId = Console.ReadLine().Trim();
            }

            int id = Convert.ToInt32(userinputId);

            return id;
        }
    }
}
