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

    private readonly DatabaseContext _context;

    public PetRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void RegisterPet(Pet pet)
    {
        _context.Pets.Add(pet);
    }

    public List<Pet> ShowAllPets()
    {
        return _context.Pets;
    }

    public Pet GetPetById(Guid id)
    {
        
        return _context.Pets.FirstOrDefault(p => p.Id == id);
    }

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

    public void DeletePet(Guid id)
    {
        var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
        if (pet != null)
        {
            _context.Pets.Remove(pet);
        }
    }

    // 🔹 Método extra para filtrar mascotas por cliente
    public List<Pet> GetPetsByCustomer(Guid customerId)
    {
        return _context.Pets.Where(p => p.OwnerId == customerId).ToList();
    }

}



