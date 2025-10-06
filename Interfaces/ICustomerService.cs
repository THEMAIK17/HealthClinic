using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Services;

using HealthClinic.Models;

namespace HealthClinic.Interfaces;

public interface ICustomerService
{
    void RegisterCustomer();
    void ShowAllCustomers();
    Customer GetCustomerById();
    void UpdateCustomer();
    void DeleteCustomer();
}
