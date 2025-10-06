using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealtClinic.Services;

using HealtClinic.Models;

namespace HealtClinic.Interfaces;

public interface ICustomerService
{
    void RegisterCustomer();
    void ShowAllCustomers();
    Customer GetCustomerById();
    void UpdateCustomer();
    void DeleteCustomer();
}
