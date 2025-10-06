using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetSystem.Models;
namespace HealtClinic.Interfaces;

public interface IPetService
{

    void RegisterPet();
    void ShowAllPets();
    Pet GetPetById();
    void UpdatePet();
    void DeletePet();
}
