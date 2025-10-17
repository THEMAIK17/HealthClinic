using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Services;
using HealthClinic.Services;

namespace HealthClinic.Utils
{
    public class ShowMenuCustomer
    {
        public readonly CustomerService _customerService;

        public ShowMenuCustomer(CustomerService customerService)
        {
            _customerService = customerService;
        }

        bool running = true;
        public void ShowMenuCustomer1()
        {
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
                    _customerService.RegisterCustomer();
                    break;
                case "2":
                    _customerService.ShowAllCustomers();
                    break;
                case "3":
                    _customerService.GetCustomerById();
                    break;
                case "4":
                    _customerService.UpdateCustomer();
                    break;
                case "5":
                    _customerService.DeleteCustomer();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

        }
    }
}