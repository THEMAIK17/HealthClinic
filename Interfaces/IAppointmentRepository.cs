using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Interfaces
{
    public interface IAppointmentRepository
    {
        // Adds a new appointment to the repository
        void RegisterAppointment(Appointment appointment);

        // Retrieves all appointments
        List<Appointment> ShowAllAppointments();

        // Finds an appointment by its ID
        Appointment GetAppointmentById(Guid id);

        // Updates an existing appointment
        void UpdatedAppointment(Appointment appointment);

        // Removes an appointment by its ID
        void DeleteAppointment(Guid id);

    }
}