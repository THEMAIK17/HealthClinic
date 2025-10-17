// Implementar la clase Mascota con atributos (nombre, especie, raza, edad)
// y métodos (mostrar información).

namespace HealthClinic.Models;

public class Pet : Animal
{
    // Breed of the pet
    public string Breed { get; set; }

    // ID of the owner (customer) related to this pet
    public Guid OwnerId { get; set; }

    // Constructor to initialize the pet's basic properties and breed
    public Pet(string name,
                string specie,
                byte age,
                string breed)
                : base(name, specie, age)
    {
        Id = Guid.NewGuid();
        Breed = breed;
    }

    // Displays detailed info about the pet
    public virtual string ShowInfo()
    {
        return  $@"Id: {Id}, 
                Pet: {Name}, 
                Specie: {Specie}, 
                Breed: {Breed}, 
                Age: {Age} , 
                Id owner: {OwnerId}";
    }

    // Emits the sound typical for the pet's species
    public override void SoundEmit()
    {
        var sounds = new Dictionary<string, string>
        {
            { "dog", "Guau 🐶" },
            { "cat", "Miau 🐱" },
            { "parrot", "¡hello! 🦜" },
            { "hamster", "Squeak 🐹" },
            { "rabbit", "Sniff 🐰" },
            { "fish", "Blub blub 🐟" },
            { "turtle", "..." },
            { "lizard", "..." },
            { "snake", "Ssssss 🐍" },
            { "bird", "Chirp chirp 🐦" },
            { "frog", "Ribbit 🐸" },
            { "horse", "Neigh 🐴" }
        };

        if (sounds.ContainsKey(Specie.ToLower()))
            Console.WriteLine($"{Name} says: {sounds[Specie.ToLower()]}");
        else
            Console.WriteLine($"{Name} makes an unknown sound...");
    }

    // Returns a short summary string with pet's name and species
    public string ShowSummary()
    {
        return $"{Name} ({Specie})";
    }
}