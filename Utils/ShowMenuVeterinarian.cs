using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Services;

namespace HealthClinic.Utils
{
    public class ShowMenuVeterinarian
    {
        public readonly VeterinarianService _veterinarianService;

        public ShowMenuVeterinarian(VeterinarianService veterinarianService)
        {
            _veterinarianService = veterinarianService;
        }

        bool running = true;
        public void showMenuVeterinarian1()
        {
            Console.Clear();
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. registrar médico veterinario");
            Console.WriteLine("2. mostrar todos los médicos veterinarios");
            Console.WriteLine("3. buscar veterinario por ID");
            Console.WriteLine("4. editar médico veterinario");
            Console.WriteLine("5. eliminar veterinario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string optionVeterinarian = Console.ReadLine() ?? "";
            switch (optionVeterinarian)
            {
                case "1":
                    _veterinarianService.RegisterVeterinarian();   
                    break;
                case "2":
                    _veterinarianService.ShowAllVeterinarians();
                    break;
                case "3":
                    _veterinarianService.GetVeterinarianById(); 
                    break;
                case "4":
                    _veterinarianService.UpdateVeterinarian();
                    break;
                case "5":
                    _veterinarianService.DeleteVeterinarian();
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