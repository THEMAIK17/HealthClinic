using HealthClinic.Services;
using HealthClinic.Repositories;
using HealthClinic.Database;
using HealthClinic.Models;
using HealthClinic.services;
using HealthClinic.Utils;

var dbContext = new DatabaseContext();

var customerRepository = new CustomerRepository(dbContext);
var customerService = new CustomerService(customerRepository);

var petRepository = new PetRepository(dbContext);
var petService = new PetService(petRepository, dbContext.Customers);

var veterinarianRepository = new VeterinarianRepository(dbContext);
var veterinarianService = new VeterinarianService(veterinarianRepository);

var appointmentRepository = new AppointmentRepository(dbContext);
var appointmentService = new AppointmentService(
    appointmentRepository,
    customerRepository,
    petRepository,
    veterinarianRepository
);
var showMenuCustomer = new ShowMenuCustomer(customerService);
var showMenuPet = new ShowMenuPet(petService);
var showMenuVeterinarian = new ShowMenuVeterinarian(veterinarianService);
var showMenuAppointment = new ShowMenuAppointment(appointmentService);

appointmentService.SeedAllData();

bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("\n--- Menú Principal ---");
    Console.WriteLine("1. tramites clientes");
    Console.WriteLine("2. tramites mascotas");
    Console.WriteLine("3. tramites veterinarios");
    Console.WriteLine("4. apartado de citas");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");
    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            showMenuCustomer.ShowMenuCustomer1();
            break;
        case "2":
            showMenuPet.ShowMenuPet1();
            break;
        case "3":
            showMenuVeterinarian.showMenuVeterinarian1();
            break;
        case "4":
            showMenuAppointment.ShowMenuAppointment1();
            break;
        case "0":
            running = false;
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

    if (running)
    {
        Console.WriteLine("press a button to continue");
        Console.ReadKey();
    }
}

