using HospitalManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalManagment.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Perciption>()
            //.HasOne(p => p.Patient)
            //.WithMany()
            //.HasForeignKey(p => p.PatientId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Perciption>()
            //    .HasOne(p => p.Doctor)
            //    .WithMany()
            //    .HasForeignKey(p => p.DoctorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// علاقة Appoinitment مع Doctor
            //modelBuilder.Entity<Appoinitment>()
            //    .HasOne(a => a.Doctor)
            //    .WithMany(d => d.Appoinitments) // Navigation property في Doctor
            //    .HasForeignKey(a => a.DoctorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// علاقة Appoinitment مع Patient
            //modelBuilder.Entity<Appoinitment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appoinitments) // Navigation property في Patient
            //    .HasForeignKey(a => a.PatientId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// علاقة Appoinitment مع Clinic
            //modelBuilder.Entity<Appoinitment>()
            //    .HasOne(a => a.Clinic)
            //    .WithMany() // يمكن عمل قائمة Appoinitments في Clinic لو حبيت
            //    .HasForeignKey(a => a.ClinicId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Perciption> Perciptions { get; set; }

        public DbSet<Appoinitment> Appoinitments { get; set; }
    }
}
