using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoctorsAPI.Model.DBContext
{
    public partial class DoctorsDBContext : DbContext
    {
        public DoctorsDBContext()
        {
        }

        public DoctorsDBContext(DbContextOptions<DoctorsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DoctorsDB;Integrated Security=True");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Arname)
                    .HasColumnName("ARName")
                    .HasMaxLength(50);

                entity.Property(e => e.Enname)
                    .HasColumnName("ENName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(200);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.Property(e => e.PhotosUrl).HasColumnName("PhotosURL");

                entity.Property(e => e.SpecialityId).HasColumnName("SpecialityID");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_Doctor_Specialty");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.MailId)
                    .HasColumnName("MailID")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Email_Doctor");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArlocationName)
                    .HasColumnName("ARLocationName")
                    .HasMaxLength(300);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.EnlocationName)
                    .HasColumnName("ENLocationName")
                    .HasMaxLength(300);

                entity.Property(e => e.Latitude).HasMaxLength(200);

                entity.Property(e => e.Longitude).HasMaxLength(200);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Location_Doctor");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Phone_Doctor");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Arname)
                    .HasColumnName("ARName")
                    .HasMaxLength(200);

                entity.Property(e => e.Enname)
                    .HasColumnName("ENName")
                    .HasMaxLength(200);
            });
        }
    }
}
