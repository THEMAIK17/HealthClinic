using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Database
{
    public class DatabaseContext
    {
        // In-memory storage for customers
        private List<Customer> _customers = new List<Customer>();
        public List<Customer> Customers => _customers;

        // In-memory storage for pets
        private List<Pet> _pets = new List<Pet>();
        public List<Pet> Pets => _pets;

        // In-memory storage for veterinarians
        private List<Veterinarian> _veterinarians = new List<Veterinarian>();
        public List<Veterinarian> Veterinarians => _veterinarians;

        // In-memory storage for appointments
        private List<Appointment> _Appointments = new List<Appointment>();
        public List<Appointment> Appointments => _Appointments;
    }
}