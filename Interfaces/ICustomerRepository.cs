using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Services;
using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface ICustomerRepository
{
    void RegisterCustomer(Customer customer);
    List<Customer> ShowAllCustomers();
    Customer GetCustomerById(Guid id);
    void UpdateCustomer(Customer updatedCustomer);
    void DeleteCustomer(Guid id);
}
