using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Repositories;
using HealthClinic.Models;


namespace HealthClinic.services;

public class VeterinarianService
{
    private readonly VeterinarianRepository _repository;

    public VeterinarianService(VeterinarianRepository repository)
    {
        _repository = repository;

    }

    public void RegisterVeterinarian()
    {
        Console.WriteLine("Registering a new veterinarian...");

        Console.Write("Enter Name: ");
        var name = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine(" Name is required.");
            return;
        }

        Console.Write("Enter Last Name: ");
        var lastName = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine(" Last Name is required.");
            return;
        }

        Console.Write("Enter Document Type: ");
        var documentType = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(documentType))
        {
            Console.WriteLine(" Document Type is required.");
            return;
        }

        Console.Write("Enter Document: ");
        var document = Console.ReadLine().Trim();
        if (_repository.ShowAllVeterinarians().Any(v => v.Document == document))
        {
            Console.WriteLine(" Document already exists.");
            return;
        }
        Console.Write("Enter Email: ");
        var email = Console.ReadLine().Trim();
        if (!email.Contains("@"))
        {
            Console.WriteLine(" Invalid email format.");
            return;
        }
        if (_repository.ShowAllVeterinarians().Any(v => v.Email == email))
        {
            Console.WriteLine(" Email already exists.");
            return;
        }
        Console.Write("Enter Age: ");
        if (!byte.TryParse(Console.ReadLine(), out byte age) || age == 0)
        {
            Console.WriteLine(" Invalid age.");
            return;
        }

        Console.Write("Enter Address: ");
        var address = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(address))
        {
            Console.WriteLine(" Address is required.");
            return;
        }
        Console.Write("Enter Phone: ");
        var phone = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(phone))
        {
            Console.WriteLine(" Phone is required.");
            return;
        }
        Console.Write("Enter Birth Day (YYYY-MM-DD): ");
        if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly birthDay))
        {
            Console.WriteLine(" Invalid date format.");
            return;
        }
        Console.Write("Enter License Number: ");
        var licenseNumber = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(licenseNumber))
        {
            Console.WriteLine(" License Number is required.");
            return;
        }
        if (_repository.ShowAllVeterinarians().Any(v => v.LicenseNumber == licenseNumber))
        {
            Console.WriteLine(" License Number already exists.");
            return;
        }
        Console.Write("Enter Specialty: ");
        var specialty = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(specialty))
        {
            Console.WriteLine(" Specialty is required.");
            return;
        }
        Console.Write("Enter Years of Experience: ");
        if (!int.TryParse(Console.ReadLine(), out int yearsOfExperience) || yearsOfExperience < 0)
        {
            Console.WriteLine(" Invalid years of experience.");
            return;
        }
        Console.Write("Enter Shift (e.g., Morning, Afternoon): ");
        var shift = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(shift))
        {
            Console.WriteLine(" Shift is required.");
            return;
        }
        Console.Write("Enter Clinic Address: ");
        var clinicAddress = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(clinicAddress))
        {
            Console.WriteLine(" Clinic Address is required.");
            return;
        }
        var veterinarian = new Veterinarian(name,
                                              lastName,
                                              documentType,
                                              document,
                                              email,
                                              age,
                                              address,
                                              phone,
                                              birthDay,
                                              licenseNumber,
                                              specialty,
                                              yearsOfExperience,
                                              shift,
                                              clinicAddress);
        _repository.RegisterVeterinarian(veterinarian);
        Console.WriteLine("Veterinarian registered successfully!");
    }

    public void ShowAllVeterinarians()
    {
        var veterinarians = _repository.ShowAllVeterinarians();
        if (veterinarians.Count == 0)
        {
            Console.WriteLine("No veterinarians found.");
            return;
        }

        Console.WriteLine("List of Veterinarians:");
        foreach (var vet in veterinarians)
        {
            vet.ToString();
            Console.WriteLine("---------------------------");
        }
    }

    public void GetVeterinarianById(Guid id)
    {
        var vet = _repository.GetVeterinarianById(id);
        if (vet == null)
        {
            Console.WriteLine("Veterinarian not found.");
            return;
        }
        vet.ToString();
    }

    public void UpdateVeterinarian()
    {
        Console.Write("Enter the ID of the veterinarian to update: ");
        string input = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (!Guid.TryParse(input, out Guid vetId))
        {
            Console.WriteLine(" Invalid ID format.");
            return;
        }

        var existingVet = _repository.GetVeterinarianById(vetId);
        if (existingVet == null)
        {
            Console.WriteLine(" Veterinarian not found.");
            return;
        }

        Console.WriteLine("Leave fields empty to keep current values.");

        Console.Write($"Enter Name ({existingVet.Name}): ");
        var name = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(name)) name = existingVet.Name;

        Console.Write($"Enter Last Name ({existingVet.LastName}): ");
        var lastName = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(lastName)) lastName = existingVet.LastName;

        Console.Write($"Enter Document Type ({existingVet.DocumentType}): ");
        var documentType = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(documentType)) documentType = existingVet.DocumentType;

        Console.Write($"Enter Document ({existingVet.Document}): ");
        var document = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(document)) document = existingVet.Document;
        else if (_repository.ShowAllVeterinarians().Any(v => v.Document == document && v.Id != vetId))
        {
            Console.WriteLine(" Document already exists.");
            return;
        }

        Console.Write($"Enter Email ({existingVet.Email}): ");
        var email = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(email)) email = existingVet.Email;
        else if (!email.Contains("@"))
        {
            Console.WriteLine(" Invalid email format.");
            return;
        }
        else if (_repository.ShowAllVeterinarians().Any(v => v.Email == email && v.Id != vetId))
        {
            Console.WriteLine(" Email already exists.");
            return;
        }

        Console.Write($"Enter Age ({existingVet.Age}): ");
        var ageInput = Console.ReadLine().Trim();
        byte age;
        if (string.IsNullOrWhiteSpace(ageInput)) age = existingVet.Age;
        else if (!byte.TryParse(ageInput, out age) || age == 0)
        {
            Console.WriteLine(" Invalid age.");
            return;
        }
        Console.Write($"Enter Address ({existingVet.Address}): ");
        var address = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(address)) address = existingVet.Address;

        Console.Write($"Enter Phone ({existingVet.Phone}): ");
        var phone = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(phone)) phone = existingVet.Phone;
        Console.Write($"Enter Birth Day ({existingVet.BirthDay}): ");
        var birthDayInput = Console.ReadLine().Trim();
        DateOnly birthDay;
        if (string.IsNullOrWhiteSpace(birthDayInput)) birthDay = existingVet.BirthDay;
        else if (!DateOnly.TryParse(birthDayInput, out birthDay))
        {
            Console.WriteLine(" Invalid date format.");
            return;
        }
        Console.Write($"Enter License Number ({existingVet.LicenseNumber}): ");
        var licenseNumber = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(licenseNumber)) licenseNumber = existingVet.LicenseNumber;
        else if (_repository.ShowAllVeterinarians().Any(v => v.LicenseNumber == licenseNumber && v.Id != vetId))
        {
            Console.WriteLine(" License Number already exists.");
            return;
        }

        Console.Write($"Enter Specialty ({existingVet.Specialty}): ");
        var specialty = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(specialty)) specialty = existingVet.Specialty;
        Console.Write($"Enter Years of Experience ({existingVet.YearsOfExperience}): ");
        var yoeInput = Console.ReadLine().Trim();
        int yearsOfExperience;
        if (string.IsNullOrWhiteSpace(yoeInput)) yearsOfExperience = existingVet.YearsOfExperience;
        else if (!int.TryParse(yoeInput, out yearsOfExperience) || yearsOfExperience < 0)
        {
            Console.WriteLine(" Invalid years of experience.");
            return;
        }
        Console.Write($"Enter Shift ({existingVet.Shift}): ");
        var shift = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(shift)) shift = existingVet.Shift;
        Console.Write($"Enter Clinic Address ({existingVet.ClinicAddress}): ");
        var clinicAddress = Console.ReadLine().Trim().ToLower();
        if (string.IsNullOrWhiteSpace(clinicAddress)) clinicAddress = existingVet.ClinicAddress;
        var updatedVet = new Veterinarian(name,
                                              lastName,
                                              documentType,
                                              document,
                                              email,
                                              age,
                                              address,
                                              phone,
                                              birthDay,
                                              licenseNumber,
                                              specialty,
                                              yearsOfExperience,
                                              shift,
                                              clinicAddress)
        {
            Id = existingVet.Id
        };
        _repository.UpdateVeterinarian(updatedVet);
        Console.WriteLine("Veterinarian updated successfully!");
    }
    public void DeleteVeterinarian()
    {
        Console.Write("Enter the ID of the veterinarian to delete: ");
        string input = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (!Guid.TryParse(input, out Guid vetId))
        {
            Console.WriteLine(" Invalid ID format.");
            return;
        }

        var existingVet = _repository.GetVeterinarianById(vetId);
        if (existingVet == null)
        {
            Console.WriteLine(" Veterinarian not found.");
            return;
        }

        _repository.DeleteVeterinarian(vetId);
        Console.WriteLine("Veterinarian deleted successfully!");
    }

    internal void GetVeterinarianById()
    {
        throw new NotImplementedException();
    }
}

