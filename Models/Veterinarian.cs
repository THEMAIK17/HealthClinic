using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Models;


public class Veterinarian : Person
{
    // Identificador único
    public Guid Id { get; set; }

    // Información profesional
    public string LicenseNumber { get; set; }    // Número de licencia profesional
    public string Specialty { get; set; }        // Ejemplo: "Cirugía", "Dermatología"
    public int YearsOfExperience { get; set; }   // Años de experiencia
    public string Shift { get; set; }            // Turno de trabajo ("Mañana", "Tarde", etc.)

    public string ClinicAddress { get; set; }    // Dirección de la clínica

    // Relación con citas (no con mascotas)
    // public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    // Constructor
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
        Id = Guid.NewGuid();
        LicenseNumber = licenseNumber;
        Specialty = specialty;
        YearsOfExperience = yearsOfExperience;
        Shift = shift;
        ClinicAddress = clinicAddress;
    }
    
    public override void ToString()
    {
        base.ToString();
        Console.WriteLine($"ID: {Id}, Name: {Name} {LastName}, Document: {Document}, Email: {Email}, Age: {Age}, Address: {Address}, Phone: {Phone}, Birth Day: {BirthDay}, License Number: {LicenseNumber}, Specialty: {Specialty}, Years of Experience: {YearsOfExperience}, Shift: {Shift}, Clinic Address: {ClinicAddress}");
    }
}


