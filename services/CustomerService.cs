using HealthClinic.Models;
using HealthClinic.Models;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.Repositories;

namespace HealthClinic.Services;

public class CustomerService 
{

    private readonly CustomerRepository _repository = new CustomerRepository();

 
    public void RegisterCustomer()
    {
        Console.WriteLine("\n=== 🧾 Register New Customer ===");

        Console.Write("Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("⚠️ Name is required.");
            return;
        }

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("⚠️ Last Name is required.");
            return;
        }

        Console.Write("Document Type: ");
        string documentType = Console.ReadLine();

        Console.Write("Document: ");
        string document = Console.ReadLine();
        if (_repository.ShowAllCustomers().Any(c => c.Document == document))
        {
            Console.WriteLine("⚠️ Document already exists.");
            return;
        }

        Console.Write("Email: ");
        string email = Console.ReadLine();
        if (!email.Contains("@"))
        {
            Console.WriteLine("⚠️ Invalid email format.");
            return;
        }
        if (_repository.ShowAllCustomers().Any(c => c.Email == email))
        {
            Console.WriteLine("⚠️ Email already exists.");
            return;
        }

        Console.Write("Age: ");
        byte age = 0;
        try
        {
            age = byte.Parse(Console.ReadLine());
            if (age < 1 || age > 120)
            {
                Console.WriteLine("⚠️ Age must be between 1 and 120.");
                return;
            }
        }
        catch
        {
            Console.WriteLine("⚠️ Invalid age format. Enter numbers only.");
            return;
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Birth Day (YYYY-MM-DD): ");
        DateOnly birthDay;
        try
        {
            birthDay = DateOnly.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("⚠️ Invalid date format. Example: 2000-05-25");
            return;
        }

        Customer customer = new Customer(name, lastName, documentType, document, email, age, address, phone, birthDay);
        _repository.RegisterCustomer(customer);

        Console.WriteLine($"\n✅ Customer {customer.Name} registered successfully!\n");
    }
    public List<Customer> GetAllCustomers()
    {
        return _repository.ShowAllCustomers();
    }

    // ✅ MOSTRAR CLIENTES
    public void ShowAllCustomers()
    {
        var customers = _repository.ShowAllCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("⚠️ No customers registered.");
            return;
        }

        Console.WriteLine("\n📋 Registered Customers:\n");
        foreach (var c in customers)
        {
            Console.WriteLine($"🧍 ID: {c.Id}");
            Console.WriteLine($"Name: {c.Name} {c.LastName}");
            Console.WriteLine($"Document: {c.DocumentType} - {c.Document}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine($"Age: {c.Age}");
            Console.WriteLine($"Address: {c.Address}");
            Console.WriteLine($"Phone: {c.Phone}");
            Console.WriteLine($"Birth Day: {c.BirthDay}\n");
        }
    }

    // ✅ BUSCAR CLIENTE POR ID
    public Customer GetCustomerById()
    {
        Console.Write("Enter the ID of the customer to search: ");
        string id = Console.ReadLine();

        if (Guid.TryParse(id, out Guid guid))
        {
            var customer = _repository.GetCustomerById(guid);

            if (customer != null)
            {
                Console.WriteLine("\n✅ Customer found:\n");
                Console.WriteLine($"Name: {customer.Name} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone: {customer.Phone}");
            }
            else
            {
                Console.WriteLine("❌ Customer not found.");
            }

            return customer;
        }
        else
        {
            Console.WriteLine("⚠️ Invalid ID format.");
            return null;
        }
    }

    // ✅ ACTUALIZAR CLIENTE
    public void UpdateCustomer()
    {
        Console.Write("Enter the ID of the customer to update: ");
        string id = Console.ReadLine();

        if (!Guid.TryParse(id, out Guid guid))
        {
            Console.WriteLine("⚠️ Invalid ID format.");
            return;
        }

        var customer = _repository.GetCustomerById(guid);

        if (customer == null)
        {
            Console.WriteLine("❌ Customer not found.");
            return;
        }

        Console.WriteLine($"\nUpdating data for {customer.Name} {customer.LastName}:");

        Console.Write("New Name (leave empty to keep current): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            customer.Name = name;

        Console.Write("New Email (leave empty to keep current): ");
        string email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!email.Contains("@"))
            {
                Console.WriteLine("⚠️ Invalid email. Update cancelled.");
                return;
            }
            customer.Email = email;
        }

        Console.Write("New Age (leave empty to keep current): ");
        string ageInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(ageInput))
        {
            try
            {
                customer.Age = byte.Parse(ageInput);
            }
            catch
            {
                Console.WriteLine("⚠️ Invalid age. Update cancelled.");
                return;
            }
        }

        _repository.UpdateCustomer(customer);
        Console.WriteLine($"\n✅ Customer {customer.Name} updated successfully!\n");
    }

    // ✅ ELIMINAR CLIENTE
    public void DeleteCustomer()
    {
        Console.Write("Enter the ID of the customer to delete: ");
        string id = Console.ReadLine();

        if (!Guid.TryParse(id, out Guid guid))
        {
            Console.WriteLine("⚠️ Invalid ID format.");
            return;
        }

        _repository.DeleteCustomer(guid);
        Console.WriteLine("\n🗑️ Customer deleted successfully (if it existed).\n");
    }
}