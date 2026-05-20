namespace LibrarySystem
{
    public static class FileManager
    {
        private static string filePath = "library_data.txt";

        // Simulerar att skicka data (Spara till fil)
        public static void SaveData(string data)
        {
            try 
            {
                File.WriteAllText(filePath, data);
                Console.WriteLine("System: Data har synkroniserats med servern.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kritiskt fel vid sparande: " + ex.Message);
            }
        }

        // Simulerar att hämta data (Läsa från fil)
        public static string LoadData()
        {
            if (File.Exists(filePath))
                return File.ReadAllText(filePath);
            return "Ingen data hittades.";
        }
    }
}