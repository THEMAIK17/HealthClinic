using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Models;


public class Appointment
{
    public Guid Id { get; set; }                 
    public DateTime Date { get; set; }            
    public string Reason { get; set; }             
    public string Status { get; set; }             
    public string Notes { get; set; }              

    // Relaciones
    public Customer Customer { get; set; }         
    public Pet Pet { get; set; }                   
    public Veterinarian Veterinarian { get; set; } 

    // Constructor
    public Appointment(DateTime date,
                        string reason,
                        Customer customer,
                        string status,
                        Pet pet,
                        Veterinarian veterinarian)
    {
        Id = Guid.NewGuid();
        Date = date;
        Reason = reason;
        Status = status;  
        Customer = customer;
        Pet = pet;
        Veterinarian = veterinarian;
    }

    public virtual string ShowInfoAppointment()
    {
        return $@"  Id: {Id}
                    Date: {Date}
                    reason:{Reason}
                    Status:{Status}
                    Customer:{Customer.ShowSummary()}
                    Pet:{Pet.ShowSummary()}
                    Veterinarian: {Veterinarian.ShowSummary()}
        ";
        
    }


    // Método opcional para actualizar el estado
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }



}

