using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Interfaces;
using HealthClinic.Models;

namespace HealthClinic.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private List<Customer> Customers = new List<Customer>();

        public void RegisterCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public List<Customer> ShowAllCustomers()
        {
            return Customers;
        }

        public Customer GetCustomerById(Guid id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            var existingCustomer = Customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = updatedCustomer.Name;
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.DocumentType = updatedCustomer.DocumentType;
                existingCustomer.Document = updatedCustomer.Document;
                existingCustomer.Email = updatedCustomer.Email;
                existingCustomer.Age = updatedCustomer.Age;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.Phone = updatedCustomer.Phone;
                existingCustomer.BirthDay = updatedCustomer.BirthDay;
            }
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Customers.Remove(customer);
            }
        }

    }
}