using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealtClinic.Models;
using HealtClinic.Models;
using HealtClinic.Interfaces;
using HealtClinic.Models;

namespace HealtClinic.Services;

public class PetService : IPetService
{
    private readonly List<Customer> _customers;
    public PetService(List<Customer> Customers)
    {
        _customers = Customers;
    }
    public void RegisterPet()
    {
        Console.WriteLine("Enter pet details:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Specie: ");
        string specie = Console.ReadLine();

        Console.Write("Breed: ");
        string breed = Console.ReadLine();

        Console.Write("Age: ");
        byte age = byte.Parse(Console.ReadLine());

        Pet pet = new Pet(name, specie, age, breed);

        Console.Write("Enter the Id of the customer to assign this pet: ");
        string input = Console.ReadLine() ?? "";
        if (Guid.TryParse(input, out Guid customerId))
        {
            // Buscar el cliente por Id
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);

            if (customer != null)
            {
                customer.Pets.Add(pet);
                Console.WriteLine($"Pet {pet.Name} registered to {customer.Name}.");
            }
            else
            {
                Console.WriteLine("Customer not found. Pet not registered.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Id format.");
        }
    }
    public void ShowAllPets()
    {
        foreach (var customer in _customers)
        {
            customer.ToString();
            foreach (var pet in customer.Pets)
            {
                pet.ShowInfo();
                pet.SoundEmit();
            }
        }

    }

    public Pet GetPetById()
    {
        Console.Write("\nEnter the Pet ID: ");
        string input = Console.ReadLine();

        foreach (var customer in _customers)
        {
            var pet = customer.Pets.FirstOrDefault(p => p.Id.ToString() == input);
            if (pet != null)
            {
                Console.WriteLine("\n✅ Pet found:\n");
                pet.ShowInfo();
                return pet;
            }
        }

        Console.WriteLine("\n❌ Pet not found.");
        return null;
    }

    // ------------------ UPDATE ------------------
    public void UpdatePet()
    {
        Console.WriteLine("\n=== Update Pet ===");
        var pet = GetPetById();

        if (pet != null)
        {
            Console.Write($"New Name (current: {pet.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                pet.Name = name;

            Console.Write($"New Specie (current: {pet.Specie}): ");
            string specie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(specie))
                pet.Specie = specie;

            Console.Write($"New Breed (current: {pet.Breed}): ");
            string breed = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(breed))
                pet.Breed = breed;

            Console.Write($"New Age (current: {pet.Age}): ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
                pet.Age = byte.Parse(ageInput);

            Console.WriteLine($"\n✅ Pet '{pet.Name}' updated successfully!");
        }
    }

    // ------------------ DELETE ------------------
    public void DeletePet()
    {
        Console.WriteLine("\n=== Delete Pet ===");
        var pet = GetPetById();

        if (pet != null)
        {
            foreach (var customer in _customers)
            {
                if (customer.Pets.Remove(pet))
                {
                    Console.WriteLine($"\n🗑️ Pet '{pet.Name}' deleted successfully.");
                    return;
                }
            }
        }

        Console.WriteLine("\n❌ Pet not found.");
    }

    

}
    

