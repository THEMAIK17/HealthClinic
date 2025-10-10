using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.Database;

namespace HealthClinic.Repositories;

public class PetRepository : IPetRepository
{
    private readonly DatabaseContext _context; // Database context instance

    public PetRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Adds a new pet to the database
    public void RegisterPet(Pet pet)
    {
        _context.Pets.Add(pet);
    }

    // Returns the list of all pets
    public List<Pet> ShowAllPets()
    {
        return _context.Pets;
    }

    // Finds a pet by its unique ID
    public Pet GetPetById(Guid id)
    {
        return _context.Pets.FirstOrDefault(p => p.Id == id);
    }

    // Updates an existing pet's data
    public void UpdatePet(Pet updatedPet)
    {
        var pet = _context.Pets.FirstOrDefault(p => p.Id == updatedPet.Id);
        if (pet != null)
        {
            pet.Name = updatedPet.Name;
            pet.Specie = updatedPet.Specie;
            pet.Breed = updatedPet.Breed;
            pet.Age = updatedPet.Age;
            pet.OwnerId = updatedPet.OwnerId;
        }
    }

    // Removes a pet by its ID
    public void DeletePet(Guid id)
    {
        var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
        }
    }

    // Returns a list of pets owned by a specific customer
    public List<Pet> GetPetsByCustomer(Guid customerId)
    {
        return _context.Pets.Where(p => p.OwnerId == customerId).ToList();
    }
}