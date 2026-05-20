using System;

namespace APIStarwarsBrawl;

public class StarWarsCharacter
{
    // Namnen här måste matcha JSON-nycklarna exakt (Name, Mass)
    public string Name { get; set; }
    public string Mass { get; set; }
}
