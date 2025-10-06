
namespace HealthClinic.Models;

public abstract class Animal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }
    public byte Age { get; set; }
    public Animal(string name, string specie, byte age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Specie = specie;
        Age = age;
    }

    public virtual void SoundEmit()
    {
        
    }

    
}