using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Models;
using HealthClinic.Models;

namespace HealthClinic.Models
{
    public class Customer : Person
    {
        // List of pets owned by the customer
        internal List<Pet> Pets { get; set; } = new List<Pet>();

        // Constructor initializing customer properties and generating unique ID
        internal Customer(string name,
                           string lastname,
                           string documentType,
                           string document,
                           string email,
                           byte age,
                           string address,
                           string phone,
                           DateOnly birthDay)
                           : base(name, lastname, documentType, document, email, age, address, phone, birthDay)
        {}

        // Returns a brief summary of the customer (full name)
        public string ShowSummary()
        {
            return $"{Name} {LastName}";
        }
    }
}