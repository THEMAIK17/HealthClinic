using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface IVeterinarianRepository
{

    // Adds a new veterinarian to the repository
    void RegisterVeterinarian(Veterinarian veterinarian);

    // Retrieves all veterinarians
    List<Veterinarian> ShowAllVeterinarians();

    // Finds a veterinarian by their ID
    Veterinarian GetVeterinarianById(Guid id);

    // Updates an existing veterinarian's information
    void UpdateVeterinarian(Veterinarian updatedVeterinarian);

    // Deletes a veterinarian by their ID
    void DeleteVeterinarian(Guid id);
}



