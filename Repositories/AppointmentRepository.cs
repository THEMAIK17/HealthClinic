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
    private readonly DatabaseContext _context;

    public AppointmentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void RegisterAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
    }

    public List<Appointment> ShowAllAppointments()
    {
        return _context.Appointments;
    }

    public Appointment GetAppointmentById(Guid id)
    {
        return _context.Appointments.FirstOrDefault(a => a.Id == id);
    }

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

    public void DeleteAppointment(Guid id)
    {
        var Appointment = _context.Appointments.FirstOrDefault(c => c.Id == id);

        if (Appointment != null)
        {
            _context.Appointments.Remove(Appointment);
        }
    }
}
