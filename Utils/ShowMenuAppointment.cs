using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Database;
using HealthClinic.services;
using Microsoft.VisualBasic;
namespace HealthClinic.Utils
{
    public class ShowMenuAppointment
    {

        public readonly AppointmentService _appointmentService;

        public ShowMenuAppointment(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        bool running = true;

        public void ShowMenuAppointment1()
        {
            Console.Clear();
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. registrar cita");
            Console.WriteLine("2. mostrar todas las citas");
            Console.WriteLine("3. buscar cita por ID");
            Console.WriteLine("4. editar cita ");
            Console.WriteLine("5. eliminar cita");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string optionAppointment = Console.ReadLine() ?? "";

            switch (optionAppointment)
            {

                case "1":
                    _appointmentService.RegisterAppointment();
                    break;
                case "2":
                    _appointmentService.ShowAllAppointments();
                    break;
                case "3":
                    _appointmentService.GetAppointmentById();
                    break;
                case "4":
                    _appointmentService.UpdatedAppointment();
                    break;
                case "5":
                    _appointmentService.DeleteAppointment();
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