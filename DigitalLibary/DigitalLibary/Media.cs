namespace LibrarySystem
{
    // Basklass för alla typer av media i biblioteket
    public abstract class Media
    {
        // Grundläggande information som alla media behöver
        public string Title { get; set; }
        public int Id { get; set; }
        public bool IsAvailable { get; set; }

        // Konstruktor som sätter titel och ID
        public Media(string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }

        // Varje medietyp måste kunna visa sina detaljer
        public abstract string GetDetails();
    }
}