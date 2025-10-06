using HealthClinic.Services;


CustomerService customerService = new CustomerService();
PetService petService = new PetService(customerService.Customers);
bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("\n--- Menú Principal ---");
    Console.WriteLine("1. tramites clientes");
    Console.WriteLine("2. tramites mascotas");
    Console.WriteLine("3. tramites veterinaios");
    Console.WriteLine("4. Mostrar todas las mascotas");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");
    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. registrar cliente");
            Console.WriteLine("2. mostrar todos los clientes");
            Console.WriteLine("3. buscar cliente por ID");
            Console.WriteLine("4. editar cliente");
            Console.WriteLine("5. eliminar cliente");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string optionCustomer = Console.ReadLine() ?? "";
            switch (optionCustomer)
            {
                case "1":
                    customerService.RegisterCustomer();
                    break;
                case "2":
                    customerService.ShowAllCustomers();
                    break;
                case "3":
                    customerService.GetCustomerById();
                    break;
                case "4":
                    customerService.UpdateCustomer();
                    break;
                case "5":
                    customerService.DeleteCustomer();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

            break;
        case "2":
            Console.Clear();
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. registrar mascota");
            Console.WriteLine("2. mostrar todas las mascotas");
            Console.WriteLine("3. buscar mascota por ID");
            Console.WriteLine("4. editar mascota");
            Console.WriteLine("5. eliminar mascota");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string optionPet = Console.ReadLine() ?? "";
            switch (optionPet)
            {
                case "1":
                    petService.RegisterPet();   
                    break;
                case "2":
                    petService.ShowAllPets();
                    break;
                case "3":
                    petService.GetPetById();
                    break;
                case "4":
                    petService.UpdatePet();
                    break;
                case "5":
                    petService.DeletePet();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
            break;
        case "3":
            petService.RegisterPet();
            break;
        case "4":
            petService.ShowAllPets();
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
