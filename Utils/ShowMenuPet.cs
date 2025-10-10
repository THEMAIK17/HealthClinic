using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Services;

namespace HealthClinic.Utils
{
    public class ShowMenuPet
    {
        public readonly PetService _petService;

        public ShowMenuPet(PetService petService)
        {
            _petService = petService;
        }

        bool running = true;

        public void ShowMenuPet1()
        {

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
                    _petService.RegisterPet();
                    break;
                case "2":
                    _petService.ShowAllPets();
                    break;
                case "3":
                    _petService.GetPetById();
                    break;
                case "4":
                    _petService.UpdatePet();
                    break;
                case "5":
                    _petService.DeletePet();
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