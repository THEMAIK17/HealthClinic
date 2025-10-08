using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
namespace HealthClinic.Interfaces;

public interface IPetRepository
{

    void RegisterPet(Pet pet);
    List<Pet> ShowAllPets();
    Pet GetPetById(Guid id);
    void UpdatePet(Pet updatedPet);
    void DeletePet(Guid id);
    List<Pet> GetPetsByCustomer(Guid customerId);
}
