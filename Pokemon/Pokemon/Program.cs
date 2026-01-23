using System.Net.Http.Json;

// string content = "Hej";
// File.WriteAllText("grej.txt", content);
// string content = File.ReadAllText("grej.txt");
// Console.WriteLine(content);
// Console.ReadLine();
// File.WriteAllTextAsync("santa.json", content);

// Santa nick = JsonSerializer.Deserialize<Santa>(content);
// Console.WriteLine(nick.Name);
// Console.ReadLine();



HttpClient client = new();
client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
var result = client.GetAsync("pokemon/charmander").Result;

Pokemon p = result.Content.ReadFromJsonAsync<Pokemon>().Result;

Console.WriteLine(p.weight);

// string content = result.Content.ReadAsStringAsync().Result;
// Console.WriteLine(content);



Console.ReadLine();