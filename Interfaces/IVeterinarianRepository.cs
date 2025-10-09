using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface IVeterinarianRepository
{

    void RegisterVeterinarian(Veterinarian veterinarian);
    List<Veterinarian>ShowAllVeterinarians();
    Veterinarian GetVeterinarianById(Guid id);
    void UpdateVeterinarian(Veterinarian updatedVeterinarian);
    void DeleteVeterinarian(Guid id);
}



   