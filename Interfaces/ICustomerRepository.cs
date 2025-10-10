using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Services;
using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface ICustomerRepository
{
    // Adds a new customer to the repository
    void RegisterCustomer(Customer customer);

    // Retrieves all customers
    List<Customer> ShowAllCustomers();

    // Finds a customer by their ID
    Customer GetCustomerById(Guid id);

    // Updates the information of an existing customer
    void UpdateCustomer(Customer updatedCustomer);

    // Deletes a customer by their ID
    void DeleteCustomer(Guid id);
}
