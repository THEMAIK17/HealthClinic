
namespace HealthClinic.Models;

// Abstract base class representing an animal
public abstract class Animal
{
    // Unique identifier for the animal
    public Guid Id { get; set; }

    // Name of the animal
    public string Name { get; set; }

    // Species of the animal
    public string Specie { get; set; }

    // Age of the animal in years
    public byte Age { get; set; }

    // Constructor to initialize an animal with name, species, and age
    public Animal(string name, string specie, byte age)
    {
        Id = Guid.NewGuid();  // Generate a new unique ID
        Name = name;
        Specie = specie;
        Age = age;
    }

    // Virtual method for emitting the animal's sound; can be overridden by subclasses
    public virtual void SoundEmit()
    {
        // Default implementation empty
    }
}