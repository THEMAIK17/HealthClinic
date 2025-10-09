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
    private readonly DatabaseContext _context;


    public VeterinarianRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void RegisterVeterinarian(Veterinarian veterinarian)
    {
        _context.Veterinarians.Add(veterinarian);
    }

    public List<Veterinarian> ShowAllVeterinarians()
    {
        return _context.Veterinarians;
    }

    public Veterinarian GetVeterinarianById(Guid id)
    {
        return _context.Veterinarians.FirstOrDefault(c => c.Id == id);
    }

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

    public void DeleteVeterinarian(Guid id)
    {
        var veterinarian = _context.Veterinarians.FirstOrDefault(c => c.Id == id);
        if (veterinarian != null)
        {
            _context.Veterinarians.Remove(veterinarian);
        }
    }

}
