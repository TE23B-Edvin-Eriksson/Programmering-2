namespace LibrarySystem
{
    public class LibraryManager
    {
        // Lista med alla media i biblioteket
        private List<Media> inventory = new List<Media>();

        public bool AddMedia(Media item)
        {
            // Kollar om ID redan finns i listan
            foreach (var media in inventory)
            {
                if (media.Id == item.Id)
                {
                    return false;
                }
            }

            inventory.Add(item);
            return true;
        }

        // Skriver ut alla media
        public void ShowAllMedia()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(item.GetDetails());
            }
        }

        // Lånar ett mediaobjekt med valt ID
        public void BorrowItem(int id)
        {
            foreach (var item in inventory)
            {
                if (item.Id == id)
                {
                    if (item.IsAvailable)
                    {
                        // Markerar boken som utlånad
                        item.IsAvailable = false;
                        Console.WriteLine($"Du har nu lånat: {item.Title}");
                    }
                    else
                    {
                        Console.WriteLine("Tyvärr, mediat är inte tillgängligt.");
                    }

                    return;
                }
            }

            Console.WriteLine("Tyvärr, mediat finns inte.");
        }
    }
}