using System.Reflection.Metadata;
using HealthClinic.Models;
using HealthClinic.Models;

namespace HealthClinic.Models;

public abstract class Person
{
    private string address;
    private string phone;

    public Guid Id { get; set; }
    public String Name { get; set; }
    public String DocumentType { get; set; }

    public String LastName { get; set; }
    public String Document { get; set; }
    public String Email { get; set; }
    public Byte Age { get; set; }
    public  String Address
    {
        get => address;
        set => address = value;
    }
    public String Phone
    {
        get => phone;
        set => phone = value;
    }

    public Person(  string name,
                    string lastname,
                    string documentType,
                    string document,
                    string email,
                    byte age,
                    string address,
                    string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastname;
        DocumentType = documentType;
        Document = document;
        Email = email;
        Age = age;
        Address = address;
        Phone = phone;
    }


    // Constructor

    // Override ToString to display patient info
    public virtual void ToString()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name},Lastname: {LastName}, DocumentType: {DocumentType}, Document: {Document}, Email: {Email}, Age: {Age}, Address: {Address}, Phone: {Phone}");
    }
}