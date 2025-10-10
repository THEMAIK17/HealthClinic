using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
namespace HealthClinic.Interfaces;

public interface IPetRepository
{

    // Adds a new pet to the repository
    void RegisterPet(Pet pet);

    // Retrieves all pets
    List<Pet> ShowAllPets();

    // Finds a pet by its ID
    Pet GetPetById(Guid id);

    // Updates an existing pet's information
    void UpdatePet(Pet updatedPet);

    // Deletes a pet by its ID
    void DeletePet(Guid id);

    // Retrieves all pets belonging to a specific customer
    List<Pet> GetPetsByCustomer(Guid customerId);
}
