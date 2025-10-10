using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.Models;

namespace HealthClinic.Interfaces
{
    public interface IAppointmentRepository
    {
        void RegisterAppointment(Appointment appointment);
        List<Appointment> ShowAllAppointments();
        Appointment GetAppointmentById(Guid id);
        void UpdatedAppointment(Appointment appointment);

        void DeleteAppointment(Guid id);


    }
}