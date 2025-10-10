using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Models;


public class Appointment
{
    // Unique identifier for the appointment
    public Guid Id { get; set; }

    // Date and time of the appointment
    public DateTime Date { get; set; }

    // Reason or purpose for the appointment
    public string Reason { get; set; }

    // Current status of the appointment (e.g., scheduled, canceled)
    public string Status { get; set; }

    // Additional notes related to the appointment
    public string Notes { get; set; }

    // Relationships with other entities
    public Customer Customer { get; set; }         // Customer who booked the appointment
    public Pet Pet { get; set; }                   // Pet involved in the appointment
    public Veterinarian Veterinarian { get; set; } // Veterinarian assigned to the appointment

    // Constructor to initialize an appointment with all required information
    public Appointment(DateTime date,
                        string reason,
                        Customer customer,
                        string status,
                        Pet pet,
                        Veterinarian veterinarian)
    {
        Id = Guid.NewGuid();  // Generate a new unique ID
        Date = date;
        Reason = reason;
        Status = status;  
        Customer = customer;
        Pet = pet;
        Veterinarian = veterinarian;
    }

    // Returns a formatted string with key appointment details
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

    // Optional method to update the status of the appointment
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }
}

