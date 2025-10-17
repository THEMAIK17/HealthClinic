using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Repositories;

namespace HealthClinic.Services;

public class AppointmentService
{
    private readonly AppointmentRepository _appointmentRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly PetRepository _petRepository;

    private readonly VeterinarianRepository _veterinarianRepository;

     // Constructor injects repositories
    public AppointmentService(AppointmentRepository appointmentRepository, CustomerRepository customerRepository, PetRepository petRepository, VeterinarianRepository veterinarianRepository)
    {
        _appointmentRepository = appointmentRepository;
        _customerRepository = customerRepository;
        _petRepository = petRepository;
        _veterinarianRepository = veterinarianRepository;
    }

     // Register new appointment
    public void RegisterAppointment()
    {
        Console.WriteLine("Register your appointment");

        // Read and validate appointment date, check duplicates
        Console.WriteLine("Please enter a date in datetime format (e.g., 2025-10-10 15:30):");
        DateTime date;
        try
        {
            date = DateTime.Parse(Console.ReadLine().Trim());
            if (_appointmentRepository.ShowAllAppointments().Any(a => a.Date == date))
            {
                Console.WriteLine("Already exists an appointment with that date!");
            }
        }
        catch
        {
            Console.WriteLine("enter a correct date in datetime format (e.g., 2025-10-10 15:30)");
            return;
        }
         // Read and validate reason
        Console.WriteLine("enter the reason");

        string reason = Console.ReadLine().Trim().ToLower();

        if (string.IsNullOrWhiteSpace(reason))
        {

            Console.WriteLine("reason is required");
            return;
        }

        // Read and validate status
        Console.WriteLine("enter the status format : Programada, Completada, Cancelada");
        string status = Console.ReadLine().Trim().ToLower();

        if (string.IsNullOrWhiteSpace(status))
        {

            Console.WriteLine("status is required");
            return;
        }
        // Read and validate Customer ID
        Console.Write("Enter the Customer ID to assign this pet: ");
        string input = Console.ReadLine()?.Trim();

        if (!Guid.TryParse(input, out Guid customerId))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }
      
        Customer customer = _customerRepository.GetCustomerById(customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }
        // Read and validate Pet ID
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
        // Read and validate Veterinarian ID
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
        // Create and save appointment
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
    // Display all appointments
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
    // Find appointment by ID
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

    // Update existing appointment
    public void UpdatedAppointment()
    {
        Console.Write("Enter the ID of the appointment to update: ");
        string id = Console.ReadLine().Trim();

        if (!Guid.TryParse(id, out Guid guid))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        var appointment = _appointmentRepository.GetAppointmentById(guid);

        if (appointment == null)
        {
            Console.WriteLine(" Appointment not found.");
            return;
        }

        Console.WriteLine($"\nUpdating data for Appointment");

        // Read and validate new date
        Console.WriteLine("Please enter a date in datetime format (e.g., 2023-10-10 15:30):");
        string inputDate = Console.ReadLine().Trim();
        if (!DateTime.TryParse(inputDate, out DateTime date))
        {
            Console.WriteLine("Enter a correct date in datetime format (e.g., 2023-10-10 15:30)");
            return;
        }
        if (_appointmentRepository.ShowAllAppointments().Any(a => a.Date == date))
        {
            Console.WriteLine("An appointment already exists with that date!");
            return;
        }

        Console.WriteLine("enter the reason");
        // Read and update reason
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
        // Read and update status
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
        // Read and update Customer
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

         // Read and update Pet
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
        // Read and update Veterinarian
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
            Console.WriteLine("veterinarian not found.");
            return;
        }
        else
        {
            appointment.Veterinarian = veterinarian;
        }
        // Save updated appointment
        _appointmentRepository.UpdatedAppointment(appointment);
        Console.WriteLine($"\n appointment {appointment.Id} updated successfully!\n");


    }
    // Delete appointment by ID
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







