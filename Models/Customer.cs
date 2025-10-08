using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;
using HealthClinic.Models;
using HealthClinic.Models;

namespace HealthClinic.Models
{
    public class Customer: Person
    {
        internal DateOnly BirthDay { get; set; }
        internal List<Pet> Pets { get; set; } = new List<Pet>();

        internal Customer( string name,
                           string lastname,
                           String documentType,
                           string document,
                           string email,
                           byte age,
                           string address,
                           string phone,
                           DateOnly birthDay) 
                           : base(name,lastname,documentType,document,email, age, address, phone)
        {
            Id = Guid.NewGuid();
            BirthDay = birthDay;
        }
    }
}