using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.Database;
namespace HealthClinic.Repositories;

public class VeterinarianRepository : IVeterinarianRepository
{
    private readonly DatabaseContext _context; // Database context instance

    public VeterinarianRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Adds a new veterinarian to the database
    public void RegisterVeterinarian(Veterinarian veterinarian)
    {
        _context.Veterinarians.Add(veterinarian);
    }

    // Returns the list of all veterinarians
    public List<Veterinarian> ShowAllVeterinarians()
    {
        return _context.Veterinarians;
    }

    // Finds a veterinarian by their unique ID
    public Veterinarian GetVeterinarianById(Guid id)
    {
        return _context.Veterinarians.FirstOrDefault(c => c.Id == id);
    }

    // Updates an existing veterinarian's data
    public void UpdateVeterinarian(Veterinarian updatedVeterinarian)
    {
        var existingVeterinarian = _context.Veterinarians.FirstOrDefault(c => c.Id == updatedVeterinarian.Id);
        if (existingVeterinarian != null)
        {
            existingVeterinarian.Name = updatedVeterinarian.Name;
            existingVeterinarian.LastName = updatedVeterinarian.LastName;
            existingVeterinarian.DocumentType = updatedVeterinarian.DocumentType;
            existingVeterinarian.Document = updatedVeterinarian.Document;
            existingVeterinarian.Email = updatedVeterinarian.Email;
            existingVeterinarian.Age = updatedVeterinarian.Age;
            existingVeterinarian.Address = updatedVeterinarian.Address;
            existingVeterinarian.Phone = updatedVeterinarian.Phone;
            existingVeterinarian.BirthDay = updatedVeterinarian.BirthDay;
        }
    }

    // Removes a veterinarian by their ID
    public void DeleteVeterinarian(Guid id)
    {
        var veterinarian = _context.Veterinarians.FirstOrDefault(c => c.Id == id);
        if (veterinarian != null)
        {
            _context.Veterinarians.Remove(veterinarian);
        }
    }
}
