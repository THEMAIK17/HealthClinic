// Implementar la clase Mascota con atributos (nombre, especie, raza, edad)
// y métodos (mostrar información).

namespace HealthClinic.Models;

public class Pet : Animal
{
    public String Breed { get; set; }
    public Pet( string name,
                string specie,
                byte age,
                string breed) 
                : base(name, specie, age)
    {
        Id = Guid.NewGuid();
        Breed = breed;

    }
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Pet: {Name}, Specie: {Specie}, Breed: {Breed} , Age: {Age} ");
    }

    public override void SoundEmit()
    {
        var sounds = new Dictionary<string, string>
        {
            { "dog", "Guau 🐶" },
            { "cat", "Miau 🐱" },
            { "parrot", "¡hello! 🦜" }
        };

        if (sounds.ContainsKey(Specie.ToLower()))
            Console.WriteLine($"{Name} dice: {sounds[Specie.ToLower()]}");
        else
            Console.WriteLine($"{Name} hace un sonido desconocido...");
    }
}