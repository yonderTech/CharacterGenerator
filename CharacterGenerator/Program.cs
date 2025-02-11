// See https://aka.ms/new-console-template for more information
using CharacterGenerator;

Array values = Enum.GetValues(typeof(RaceTypes));
Random random = new Random();

for (var x = 0; x <= 5; x++)
{
    var character = new Character((RaceTypes)values.GetValue(random.Next(values.Length)));

    Console.WriteLine($"Race:\t\t{character.Race.RaceType}\n");

    character.Abilities.ForEach(a =>
    {
        Console.WriteLine($"{a.AbilityType}:\t\t{a.Value}");
    });


    foreach (var abilityPerk in character.AbilityPerks)
    {
        Console.WriteLine($"\n{abilityPerk.AbilityType.ToString()} Perks:\n\n");
        foreach (var perk in abilityPerk.Perks)
        {
            Console.WriteLine($"{perk.Title}:\t\t{perk.Value}");
        }
    }

    Console.WriteLine($"\nMovement:\t{character.Movement.Value}");

    Console.WriteLine("\t\t");

}