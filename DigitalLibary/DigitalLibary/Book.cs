namespace LibrarySystem
{
    // Book är en typ av Media
    public class Book : Media
    {
        public string Author { get; set; }

        // Skapar en bok med titel, ID och författare
        public Book(string title, int id, string author) : base(title, id)
        {
            Author = author;
        }

        // Visar information om boken
        public override string GetDetails()
        {
            string status;

            if (IsAvailable)
            {
                // Boken går att låna
                status = "Tillgänglig";
            }
            else
            {
                // Boken är redan utlånad
                status = "Utlånad";
            }

            return $"[BOK] ID: {Id} | Titel: {Title} | Författare: {Author} | Status: {status}";
        }
    }
}