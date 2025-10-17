using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Database;
using HealthClinic.Interfaces;
using HealthClinic.Models;


namespace HealthClinic.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly DatabaseContext _context;  // Database context instance

    public AppointmentRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Adds a new appointment to the database
    public void RegisterAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
    }

    // Returns the list of all appointments
    public List<Appointment> ShowAllAppointments()
    {
        return _context.Appointments;
    }

    // Finds an appointment by its unique ID
    public Appointment GetAppointmentById(Guid id)
    {
        return _context.Appointments.FirstOrDefault(a => a.Id == id);
    }

    // Updates an existing appointment with new data
    public void UpdatedAppointment(Appointment updatedAppointment)
    {
        var existingAppointment = _context.Appointments.FirstOrDefault(c => c.Id == updatedAppointment.Id);
        if (existingAppointment != null)
        {
            existingAppointment.Date = updatedAppointment.Date;
            existingAppointment.Reason = updatedAppointment.Reason;
            existingAppointment.Status = updatedAppointment.Status;
            existingAppointment.Customer = updatedAppointment.Customer;
            existingAppointment.Pet = updatedAppointment.Pet;
            existingAppointment.Veterinarian = updatedAppointment.Veterinarian;
        }
    }

    // Removes an appointment by its ID
    public void DeleteAppointment(Guid id)
    {
        var Appointment = _context.Appointments.FirstOrDefault(c => c.Id == id);
        if (Appointment != null)
        {
            _context.Appointments.Remove(Appointment);
        }
    }
}