namespace LibrarySystem
{
    class Program
    {
        // Startar programmet
        static void Main(string[] args)
        {
            LibraryManager myLibrary = new LibraryManager();
            // Exempeldata som läggs in när programmet startar
            myLibrary.AddMedia(new Book("Hur man inte programmerar C#", 101, "GUSTAV NORDLANDER"));
            myLibrary.AddMedia(new Book("''Clean Code''", 102, "SANDOR LOPEZ"));
            myLibrary.AddMedia(new Book("Hur man Röker BRAJ", 103, "RENAT ZARIPOV"));

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- BIBLIOTEK ---");
                Console.WriteLine("1. Visa alla media");
                Console.WriteLine("2. Låna bok (Ange ID)");
                Console.WriteLine("3. Lägg till bok (Ange ID)");
                Console.WriteLine("4. Spara och avsluta");
                Console.Write("Val: ");

                string input = Console.ReadLine();

                // Välj vad användaren vill göra
                switch (input)
                {
                    case "1":
                        myLibrary.ShowAllMedia();
                        break;
                    case "2":
                        Console.Write("Ange ID att låna: ");
                        // Kollar att användaren skriver ett nummer
                        if (int.TryParse(Console.ReadLine(), out int borrowId))
                        {
                            myLibrary.BorrowItem(borrowId);
                        }
                        else
                        {
                            Console.WriteLine("Fel: Du måste ange ett numeriskt ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Ange ID för boken att lägga till: ");
                        // Kollar att användaren skriver ett nummer
                        if (int.TryParse(Console.ReadLine(), out int addId))
                        {
                            Console.Write("Ange titel: ");
                            string title = Console.ReadLine();
                            Console.Write("Ange författare: ");
                            string author = Console.ReadLine();
                            myLibrary.AddMedia(new Book(title, addId, author));
                        }
                        else
                        {
                            Console.WriteLine("Fel: Du måste ange ett numeriskt ID.");
                        }
                        break;
                    case "4":
                        // Sparar att sessionen avslutas
                        FileManager.SaveData("Session avslutad " + DateTime.Now);
                        running = false;
                        break;
                    default:
                        // Ogiltigt val
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
    }
}