using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Database
{
    public class DatabaseContext
    {
        private List<Customer> _customers = new List<Customer>();
        public List<Customer> Customers => _customers;

        private List<Pet> _pets = new List<Pet>();
        public List<Pet> Pets => _pets;

        private List<Veterinarian> _veterinarians = new List<Veterinarian>();
        public List<Veterinarian> Veterinarians => _veterinarians;

        private List<Appointment> _Appointments = new List<Appointment>();
        public List<Appointment> Appointments => _Appointments;
    }
}