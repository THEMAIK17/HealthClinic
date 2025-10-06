using HealthClinic.Models;
using HealthClinic.Models;
using HealthClinic.Interfaces;
using HealthClinic.Models;

namespace HealthClinic.Services;

public class CustomerService : ICustomerService
{

    public List<Customer> Customers = new List<Customer>();

    public void RegisterCustomer()
    {
        Console.WriteLine("Enter Customer details:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastname = Console.ReadLine();

        Console.Write("Document Type: ");
        string documentName = Console.ReadLine();

        Console.Write("Document: ");
        string document = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Age: ");
        byte age = byte.Parse(Console.ReadLine());

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Birth Day (YYYY-MM-DD): ");
        DateOnly birthDay = DateOnly.Parse(Console.ReadLine());

        Customer customer = new Customer(name, lastname, documentName, document, email, age, address, phone, birthDay);
        Customers.Add(customer);
        Console.WriteLine($"Customer {customer.Name} registered.");
    }

    public void ShowAllCustomers()
    {
        foreach (var customer in Customers)
        {
            customer.ToString();
        }
    }

    public Customer GetCustomerById()
    {

        Console.WriteLine("Enter the ID of the customer to search: ");
        string id = Console.ReadLine() ?? "";
        if (Guid.TryParse(id, out Guid guid))
        {
            var customer = Customers.FirstOrDefault(c => c.Id == guid);

            if (customer != null)
            {
                Console.WriteLine("\n✅ Customer found:\n");
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine($"Name: {customer.Name} {customer.LastName}");
                Console.WriteLine($"Document Type: {customer.DocumentName}");
                Console.WriteLine($"Document: {customer.Document}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Age: {customer.Age}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"Phone: {customer.Phone}");
                Console.WriteLine($"Birth Day: {customer.BirthDay}");
            }
            else
            {
                Console.WriteLine("\n❌ Customer not found.\n");
            }

            return customer;
        }

        else
        {
            Console.WriteLine("Invalid Id format.");
            return null;
        }


    }

    public void UpdateCustomer()
{
    Console.Write("Enter the ID of the customer to update: ");
    string input = Console.ReadLine();

    if (Guid.TryParse(input, out Guid guid_update))
    {
        // Buscar directamente al cliente en la lista, sin pasar parámetro
        var existingCustomer = Customers.FirstOrDefault(c => c.Id == guid_update);

        if (existingCustomer != null)
        {
            Console.WriteLine($"\nUpdating data for {existingCustomer.Name} {existingCustomer.LastName}:\n");

            Console.Write("New Name (leave empty to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                existingCustomer.Name = name;

            Console.Write("New Last Name (leave empty to keep current): ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
                existingCustomer.LastName = lastName;

            Console.Write("New Document Type (leave empty to keep current): ");
            string documentName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(documentName))
                existingCustomer.DocumentName = documentName;

            Console.Write("New Document (leave empty to keep current): ");
            string document = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(document))
                existingCustomer.Document = document;

            Console.Write("New Email (leave empty to keep current): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
                existingCustomer.Email = email;

            Console.Write("New Age (leave empty to keep current): ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
                existingCustomer.Age = byte.Parse(ageInput);

            Console.Write("New Address (leave empty to keep current): ");
            string address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address))
                existingCustomer.Address = address;

            Console.Write("New Phone (leave empty to keep current): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone))
                existingCustomer.Phone = phone;

            Console.Write("New Birth Day (YYYY-MM-DD) (leave empty to keep current): ");
            string birthDayInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(birthDayInput))
                existingCustomer.BirthDay = DateOnly.Parse(birthDayInput);

            Console.WriteLine($"\n✅ Customer {existingCustomer.Name} updated successfully!\n");
        }
        else
        {
            Console.WriteLine("\n❌ Customer not found.\n");
        }
    }
    else
    {
        Console.WriteLine("\n⚠️ Invalid ID format.\n");
    }
}


    public void DeleteCustomer()
    {
        Console.Write("Enter the ID of the customer to delete: ");
        string input = Console.ReadLine();

        if (Guid.TryParse(input, out Guid id))
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Customers.Remove(customer);
                Console.WriteLine($"\n🗑️ Customer {customer.Name} deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("\n❌ Customer not found.\n");
            }
        }
        else
        {
            Console.WriteLine("\n⚠️ Invalid ID format.\n");
        }

    }
}