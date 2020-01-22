using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BlazingShop.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            appointment.Id = appointment.Product.Id;
            appointment.Product = null;
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }
    }
}
