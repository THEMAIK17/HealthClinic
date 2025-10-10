using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Repositories;

namespace HealthClinic.services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly PetRepository _petRepository;

        private readonly VeterinarianRepository _veterinarianRepository;

        public AppointmentService(AppointmentRepository appointmentRepository, CustomerRepository customerRepository, PetRepository petRepository, VeterinarianRepository veterinarianRepository)
        {
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
            _petRepository = petRepository;
            _veterinarianRepository = veterinarianRepository;
        }


        public void RegisterAppointment()
        {
            Console.WriteLine("Register your appointment");

            Console.WriteLine("into the date");
            DateTime date;
            try
            {
                date = DateTime.Parse(Console.ReadLine());
                if (_appointmentRepository.ShowAllAppointments().Any(a => a.Date == date))
                {
                    Console.WriteLine("Already exists an appointment with that date!");
                }
            }
            catch
            {
                Console.WriteLine("into a correct date");
                return;
            }

            Console.WriteLine("into the reason");

            string reason = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(reason))
            {

                Console.WriteLine("reason is required");
                return;
            }


            Console.WriteLine("into the status");
            string status = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(status))
            {

                Console.WriteLine("status is required");
                return;
            }

            Console.Write("Enter the Customer ID to assign this pet: ");
            string input = Console.ReadLine()?.Trim();

            if (!Guid.TryParse(input, out Guid customerId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            // Buscar el cliente en el repositorio
            Customer customer = _customerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.Write("Enter the pet ID to assign this pet: ");
            string input1 = Console.ReadLine().Trim();

            if (!Guid.TryParse(input1, out Guid petId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Pet pet = _petRepository.GetPetById(petId);
            if (pet == null)
            {
                Console.WriteLine("Pet not found.");
                return;
            }

            Console.Write("Enter the veterinarian ID to assign this pet: ");
            string input2 = Console.ReadLine().Trim();

            if (!Guid.TryParse(input2, out Guid veterinarianId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Veterinarian veterinarian = _veterinarianRepository.GetVeterinarianById(veterinarianId);
            if (veterinarian == null)
            {
                Console.WriteLine("Pet not found.");
                return;
            }

            Appointment appointment = new Appointment(date,
                                                        reason,
                                                        customer,
                                                        status,
                                                        pet,
                                                        veterinarian
                                                    );
            _appointmentRepository.RegisterAppointment(appointment);
            Console.WriteLine("Appointment registered successfully!");




        }

        public void ShowAllAppointments()
        {
            var appointments = _appointmentRepository.ShowAllAppointments();

            if (appointments.Count == 0)
            {
                Console.WriteLine("No Appointments registered");
                return;
            }

            Console.WriteLine("\n Registered Appointments:\n");

            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment.ShowInfoAppointment());
            }

        }

        public Appointment GetAppointmentById()
        {

            Console.Write("Enter the ID of the appointment to search: ");
            string id = Console.ReadLine();

            if (Guid.TryParse(id, out Guid guid))
            {
                var appointment = _appointmentRepository.GetAppointmentById(guid);

                if (appointment != null)
                {
                    Console.WriteLine(appointment.ShowInfoAppointment());
                }
                else
                {
                    Console.WriteLine(" Customer not found.");
                }

                return appointment;
            }
            else
            {
                Console.WriteLine(" Invalid ID format.");
                return null;
            }
        }


        public void UpdatedAppointment()
        {
            Console.Write("Enter the ID of the customer to update: ");
            string id = Console.ReadLine().Trim();

            if (!Guid.TryParse(id, out Guid guid))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var appointment = _appointmentRepository.GetAppointmentById(guid);

            if (appointment == null)
            {
                Console.WriteLine(" Customer not found.");
                return;
            }

            Console.WriteLine($"\nUpdating data for Appointment");

            Console.WriteLine("enter the date new");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date == null)
            {
                Console.WriteLine("Invalid date format. Example: 2000-05-25");
                return;
            }
            if (_appointmentRepository.ShowAllAppointments().Any(a => a.Date == date))
            {

                Console.WriteLine("Already exists an appointment with that date!");
            }
            else
            {
                appointment.Date = date;
            }


            string reason = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(reason))
            {

                Console.WriteLine("reason is required");
                return;
            }
            else
            {
                appointment.Reason = reason;
            }

            Console.WriteLine("into the status");
            string status = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(status))
            {

                Console.WriteLine("status is required");
                return;
            }
            else
            {
                appointment.Status = status;
            }

            Console.Write("Enter the Customer ID to assign this pet: ");
            string inputCustomer = Console.ReadLine()?.Trim();

            if (!Guid.TryParse(inputCustomer, out Guid customerIdNew))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Customer customer = _customerRepository.GetCustomerById(customerIdNew);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            else
            {
                appointment.Customer = customer;
            }

            Console.Write("Enter the pet ID to assign this pet: ");
            string input1 = Console.ReadLine().Trim();

            if (!Guid.TryParse(input1, out Guid petId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Pet pet = _petRepository.GetPetById(petId);
            if (pet == null)
            {
                Console.WriteLine("Pet not found.");
                return;
            }
            else
            {
                appointment.Pet = pet;
            }

            Console.Write("Enter the veterinarian ID to assign this pet: ");
            string input2 = Console.ReadLine().Trim();

            if (!Guid.TryParse(input2, out Guid veterinarianId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            Veterinarian veterinarian = _veterinarianRepository.GetVeterinarianById(veterinarianId);
            if (veterinarian == null)
            {
                Console.WriteLine("Pet not found.");
                return;
            }
            else
            {
                appointment.Veterinarian = veterinarian;
            }

            _appointmentRepository.UpdatedAppointment(appointment);
            Console.WriteLine($"\n appointment {appointment.Id} updated successfully!\n");




        }



        public void DeleteAppointment()
        {
            Console.Write("Enter the ID of the appointment to delete: ");
            string id = Console.ReadLine();

            if (!Guid.TryParse(id, out Guid guid))
            {
                Console.WriteLine(" Invalid ID format.");
                return;
            }

            _appointmentRepository.DeleteAppointment(guid);
            Console.WriteLine("\n appointment deleted successfully .\n");
        }
    }

}
