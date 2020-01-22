using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class AppointmentListService
    {
        private readonly ApplicationDbContext _db;
        public AppointmentListService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            Appointment obj = new Appointment();
            return _db.Appointments.Include(u => u.Product).FirstOrDefault(u => u.Id == appointmentId);
        }
       
        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.Include(u => u.Product).ToList();
        }

        public List<Product> GetProductList()
        {
            return _db.Products.ToList();
        }

        public bool CreateAppointment(Appointment objAppointment)
        {
            _db.Appointments.Add(objAppointment);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateAppointment(Appointment objAppointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(u => u.Id == objAppointment.Id);
            if (ExistingAppointment != null)
            {
                //if (objAppointment.Image == null)
                //{
                //    objAppointment.Image = ExistingAppointment.Image;
                //}
                _db.Appointments.Update(objAppointment);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteAppointment(Appointment objAppointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(u => u.Id == objAppointment.Id);
            if (ExistingAppointment != null)
            {
                _db.Appointments.Remove(ExistingAppointment);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;

        }
    }
}
