using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Models;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.Repositories;


namespace HealthClinic.Services;

public class PetService 
{
    private readonly PetRepository _repository; // Repository to manage pet data
    private readonly List<Customer> _customers; // List of customers to link pets to owners

    public PetService(PetRepository repository, List<Customer> customers)
    {
        _repository = repository; // Inject pet repository
        _customers = customers;   // Inject customer list
    }
    public void RegisterPet()
    {
        Console.WriteLine("\n=== Register New Pet ===");

        Console.Write("Name: ");
        string name = Console.ReadLine()?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine(" Name is required.");
            return;
        }

        Console.Write("Specie: ");
        string specie = Console.ReadLine()?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(specie))
        {
            Console.WriteLine(" Specie is required.");
            return;
        }

        Console.Write("Breed: ");
        string breed = Console.ReadLine()?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(breed))
        {
            Console.WriteLine(" Breed is required.");
            return;
        }

        Console.Write("Age: ");
        if (!byte.TryParse(Console.ReadLine(), out byte age) || age == 0)
        {
            Console.WriteLine(" Invalid age.");
            return;
        }

        Console.Write("Enter the Customer ID to assign this pet: ");
        string input = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (!Guid.TryParse(input, out Guid customerId))
        {
            Console.WriteLine(" Invalid ID format.");
            return;
        }

 
        var customer = _customers.FirstOrDefault(c => c.Id == customerId);
        if (customer == null)
        {
            Console.WriteLine(" Customer not found. Pet not registered.");
            return;
        }

       
        Pet pet = new Pet(name, specie, age, breed)
        {
            OwnerId = customer.Id
        };

 
        customer.Pets.Add(pet);
        _repository.RegisterPet(pet);

        Console.WriteLine($"\n Pet '{pet.Name}' successfully registered for {customer.Name}.");
    }

    // ------------------ SHOW ALL ------------------
    public void ShowAllPets()
    {
        Console.WriteLine("\n=== All Registered Pets ===");
        var pets = _repository.ShowAllPets();

        if (pets.Count == 0)
        {
            Console.WriteLine(" No pets registered yet.");
            return;
        }

        foreach (var pet in pets)
        {
            Console.WriteLine(pet.ShowInfo());
            pet.SoundEmit();
            Console.WriteLine("------------------");
        }
    }

    // ------------------ GET BY ID ------------------
    public Pet GetPetById()
    {
        Console.Write("\nEnter the Pet ID: ");
        string input = Console.ReadLine()?.Trim();

        if (!Guid.TryParse(input, out Guid petId))
        {
            Console.WriteLine(" Invalid ID format.");
            return null;
        }

        var pet = _repository.GetPetById(petId);
        if (pet == null)
        {
            Console.WriteLine(" Pet not found.");
            return null;
        }

        Console.WriteLine("\nPet found:\n");
        Console.WriteLine(pet.ShowInfo());
        return pet;
    }

    // ------------------ UPDATE ------------------
    public void UpdatePet()
    {
        Console.WriteLine("\n=== Update Pet ===");
        var pet = GetPetById();

        if (pet == null)
            return;

        Console.Write($"New Name (current: {pet.Name}): ");
        string name = Console.ReadLine()?.Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(name))
            pet.Name = name;

        Console.Write($"New Specie (current: {pet.Specie}): ");
        string specie = Console.ReadLine()?.Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(specie))
            pet.Specie = specie;

        Console.Write($"New Breed (current: {pet.Breed}): ");
        string breed = Console.ReadLine()?.Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(breed))
            pet.Breed = breed;

        Console.Write($"New Age (current: {pet.Age}): ");
        string ageInput = Console.ReadLine()?.Trim();
        if (byte.TryParse(ageInput, out byte newAge) && newAge > 0)
            pet.Age = newAge;

        _repository.UpdatePet(pet);

        Console.WriteLine($"\n Pet '{pet.Name}' updated successfully!");
    }

    // ------------------ DELETE ------------------
    public void DeletePet()
    {
        Console.WriteLine("\n=== Delete Pet ===");
        var pet = GetPetById();

        if (pet == null)
            return;

        _repository.DeletePet(pet.Id);

        var owner = _customers.FirstOrDefault(c => c.Id == pet.OwnerId);
        if (owner != null)
            owner.Pets.Remove(pet);

        Console.WriteLine($"\n Pet '{pet.Name}' deleted successfully.");
    }
}




