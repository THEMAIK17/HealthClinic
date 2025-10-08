using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
namespace HealthClinic.Interfaces;

public interface IPetRepository
{

    void RegisterPet();
    void ShowAllPets();
    Pet GetPetById();
    void UpdatePet();
    void DeletePet();
}
