using System.Net.Http.Json;

HttpClient client = new();
client.BaseAddress = new Uri("https://swapi.py4e.com/api/");

Console.WriteLine("--- VÄLKOMMEN TILL GALAKTISKA BROTTNINGS-ARENAN ---");

// Hämta spelaren (vi hårdkodar Luke som exempel, eller slumpa)
var playerResponse = client.GetAsync("people/1/").Result;
StarWarsCharacter player = playerResponse.Content.ReadFromJsonAsync<StarWarsCharacter>().Result;

// Slumpa en motståndare (ID mellan 2 och 50)
int enemyId = new Random().Next(2, 51);
var enemyResponse = client.GetAsync($"people/{enemyId}/").Result;
StarWarsCharacter enemy = enemyResponse.Content.ReadFromJsonAsync<StarWarsCharacter>().Result;

Console.WriteLine($"Du är: {player.Name} ({player.Mass} kg)");
Console.WriteLine($"Din motståndare är: {enemy.Name}");
Console.WriteLine("Tror du att din motståndare väger MER eller MINDRE än dig? (m/l)");

string guess = Console.ReadLine().ToLower();

// Logik för att jämföra "stats"
// Vi måste städa datan då API:et ibland returnerar "unknown" eller kommatecken
float pMass = CleanMass(player.Mass);
float eMass = CleanMass(enemy.Mass);

bool enemyIsHeavier = eMass > pMass;

if ((guess == "m" && enemyIsHeavier) || (guess == "l" && !enemyIsHeavier))
{
    Console.WriteLine($"RÄTT! {enemy.Name} väger {enemy.Mass} kg.");
    Console.WriteLine("Du vinner rundan med kraften på din sida!");
}
else
{
    Console.WriteLine($"FEL! {enemy.Name} väger {enemy.Mass} kg.");
    Console.WriteLine("Du blev utkastad ur arenan...");
}

// Hjälpmetod för att hantera API-datans konstigheter
static float CleanMass(string input)
{
    input = input.Replace(",", ""); // Hantera t.ex. Jabba som väger 1,358
    if (float.TryParse(input, out float result)) return result;
    return 0; // Om det står "unknown"
}

// Klassen för JSON-data
public class StarWarsCharacter
{
    public string Name { get; set; }
    public string Mass { get; set; }
}