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
    }
}