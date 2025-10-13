using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using HealthClinic.Database;
using HealthClinic.Repositories;
using HealthClinic.Utils;
using HealthClinic.Services;

namespace HealthClinic.Core;

public class AppInitializer
{
    public void Run()
    {
        // Create a new instance of the database context to manage data storage and retrieval
        var dbContext = new DatabaseContext();
        // Initialize repositories with the shared dbContext for accessing data
        var customerRepository = new CustomerRepository(dbContext);
        var petRepository = new PetRepository(dbContext);
        var veterinarianRepository = new VeterinarianRepository(dbContext);
        var appointmentRepository = new AppointmentRepository(dbContext);

        // Initialize services that provide business logic, passing the repositories (and any additional dependencies)
        var customerService = new CustomerService(customerRepository);
        var petService = new PetService(petRepository, dbContext.Customers);
        var veterinarianService = new VeterinarianService(veterinarianRepository);
        var appointmentService = new AppointmentService(
            appointmentRepository,
            customerRepository,
            petRepository,
            veterinarianRepository
        );

        // Initialize menu handlers to show UI menus for different entities, passing their corresponding services
        var showMenuCustomer = new ShowMenuCustomer(customerService);
        var showMenuPet = new ShowMenuPet(petService);
        var showMenuVeterinarian = new ShowMenuVeterinarian(veterinarianService);
        var showMenuAppointment = new ShowMenuAppointment(appointmentService);

        
        // Seed initial data for appointments (and possibly related data)
        DataSeeder.SeedAllData(customerRepository, petRepository, veterinarianRepository, appointmentRepository);

        // 6. Ejecutar el menú principal
        RunMainMenu(showMenuCustomer, showMenuPet, showMenuVeterinarian, showMenuAppointment);
    }


    private void RunMainMenu(
        ShowMenuCustomer showMenuCustomer,
        ShowMenuPet showMenuPet,
        ShowMenuVeterinarian showMenuVeterinarian,
        ShowMenuAppointment showMenuAppointment
    )
    {
        // Main program loop to display the menu and respond to user input
        bool running = true;

        while (running)
        {
            Console.Clear();     // Clear the console screen before showing the menu
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Trámites clientes");
            Console.WriteLine("2. Trámites mascotas");
            Console.WriteLine("3. Trámites veterinarios");
            Console.WriteLine("4. Apartado de citas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    showMenuCustomer.ShowMenuCustomer1(); // Show customer menu
                    break;
                case "2":
                    showMenuPet.ShowMenuPet1(); // Show pet menu
                    break;
                case "3":
                    showMenuVeterinarian.showMenuVeterinarian1(); // Show veterinarian menu
                    break;
                case "4":
                    showMenuAppointment.ShowMenuAppointment1(); // Show appointment menu
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
            // If the program is still running, wait for user to press a key before continuing
            if (running)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

