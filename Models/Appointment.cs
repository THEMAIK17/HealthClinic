using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Models;


public class Appointment
{
    public Guid Id { get; set; }                   // Identificador único de la cita
    public DateTime Date { get; set; }             // Fecha y hora de la cita
    public string Reason { get; set; }             // Motivo de la cita (vacuna, chequeo, cirugía, etc.)
    public string Status { get; set; }             // Estado: "Programada", "Completada", "Cancelada"
    public string Notes { get; set; }              // Observaciones o diagnóstico del veterinario

    // Relaciones
    public Customer Customer { get; set; }         // Cliente que solicita la cita
    public Pet Pet { get; set; }                   // Mascota atendida
    public Veterinarian Veterinarian { get; set; } // Veterinario asignado

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
        Status = "Programada";  // Valor por defecto
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
                    Customer:{Customer}
                    Pet:{Pet}
                    Veterinarian{Veterinarian}
        ";
        
    }


    // Método opcional para actualizar el estado
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }



}

