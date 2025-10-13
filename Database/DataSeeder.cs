using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Repositories;
using HealthClinic.Models;

namespace HealthClinic.Database;

public static class DataSeeder
{
    public static void SeedAllData(
          CustomerRepository customerRepository,
          PetRepository petRepository,
          VeterinarianRepository veterinarianRepository,
          AppointmentRepository appointmentRepository
      )
    {
        // Create and register a sample customer
        var customer1 = new Customer(
            "Ana", "Pérez", "DNI", "12345678", "ana.perez@example.com",
            30, "123 Main St", "555-1234", new DateOnly(1995, 5, 20)
        );
        customerRepository.RegisterCustomer(customer1);

        // Create and register a pet linked to the customer
        var pet1 = new Pet("Fido", "Dog", 4, "Labrador") { OwnerId = customer1.Id };
        petRepository.RegisterPet(pet1);
        customer1.Pets.Add(pet1);

        // Create and register a veterinarian
        var vet1 = new Veterinarian(
            "Juan", "López", "DNI", "87654321", "juan.lopez@clinicavet.com",
            45, "456 Vet St", "555-9876",
            new DateOnly(1980, 3, 15), "VET123456", "Surgery", 20, "Morning", "123 Clinic Ave"
        );
        veterinarianRepository.RegisterVeterinarian(vet1);

        // Create and register an appointment linking all entities
        var appointment1 = new Appointment(
            DateTime.Now.AddDays(1),
            "General Check-up",
            customer1,
            "Scheduled",
            pet1,
            vet1
        );
        appointmentRepository.RegisterAppointment(appointment1);
    }
}
