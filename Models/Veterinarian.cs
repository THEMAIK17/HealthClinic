using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Models;


public class Veterinarian : Person
{
    // Professional information
    public string LicenseNumber { get; set; }  
    public string Specialty { get; set; }       
    public int YearsOfExperience { get; set; }  
    public string Shift { get; set; }             

    public string ClinicAddress { get; set; }    

    

    // Constructor to initialize veterinarian details along with base person details
    public Veterinarian(
        string name,
        string lastname,
        string documenType,
        string document,
        string email,
        byte age,
        string address,
        string phone,
        DateOnly birthDay,
        string licenseNumber,
        string specialty,
        int yearsOfExperience,
        string shift,
        string clinicAddress)
        : base(name, lastname, documenType, document, email, age, address, phone, birthDay)
    {
        LicenseNumber = licenseNumber;
        Specialty = specialty;
        YearsOfExperience = yearsOfExperience;
        Shift = shift;
        ClinicAddress = clinicAddress;
    }

    // Returns a detailed string representation of the veterinarian
    public override string ToString()
    {
        return $@"{base.ToString()}
            License Number: {LicenseNumber} 
            Specialty: {Specialty}
            Years of Experience: {YearsOfExperience}
            Shift: {Shift}
            Clinic Address: {ClinicAddress}";
    }

    // Returns a short summary string with the veterinarian's full name
    public string ShowSummary()
    {
        return $"{Name} {LastName}";
    }
}


