using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Database;
using HealthClinic.Interfaces;
using HealthClinic.Models;
namespace HealthClinic.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context; // Database context instance

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Adds a new customer to the database
        public void RegisterCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        // Returns the list of all customers
        public List<Customer> ShowAllCustomers()
        {
            return _context.Customers;
        }
    
        // Finds a customer by their unique ID
        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        // Updates the data of an existing customer
        public void UpdateCustomer(Customer updatedCustomer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);
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

        // Removes a customer by their ID
        public void DeleteCustomer(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }
    }
}