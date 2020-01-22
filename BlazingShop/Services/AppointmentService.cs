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

        public Appointment GetAppointment(int appointmentId)
        {
            Appointment obj = new Appointment();
            return _db.Appointments.Include(u => u.Category).FirstOrDefault(u => u.Id == appointmentId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(u => u.Category).ToList();
        }
        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.Include(u => u.ProductId).ToList();
        }

            public List<Appointment> GetAppointmentList()
        {
            return _db.Appointments.ToList();
        }

        public bool CreateAppointment(Appointment appointment)
        {
            appointment.Id = appointment.Product.Id;
            appointment.Product = null;
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateAppointment(Appointment objAppointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(u => u.Id == objAppointment.Id);
            if (ExistingAppointment != null)
            {
                //if (objProduct.Image == null)
                //{
                //    objProduct.Image = ExistingProduct.Image;
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

        public bool DeleteAppointment(Product objAppointment)
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
