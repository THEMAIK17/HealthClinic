using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface IVeterinarianRepository
{

    void RegisterVeterinarian();
    void ShowAllVeterinarians();
    Veterinarian GetVeterinarianById();
    void UpdateVeterinarian();
    void DeleteVeterinarian();
}