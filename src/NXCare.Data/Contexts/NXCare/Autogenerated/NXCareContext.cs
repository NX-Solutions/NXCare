﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NXCare.Data.Contexts.Base;
using NXCare.Domain.Entities;

namespace NXCare.Data.Contexts.NXCare
{
    public partial class NXCareContext : BaseContext<NXCareContext>
    {
        public NXCareContext()
        {
        }

        public NXCareContext(DbContextOptions<NXCareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAddress> PatientAddress { get; set; }
        public virtual DbSet<Physician> Physician { get; set; }
        public virtual DbSet<PhysicianAddress> PhysicianAddress { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Transition> Transition { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=NXCare.Sql;Integrated Security=true");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.CountryId)
                    .HasName("IX_Address_Country");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Floor).HasMaxLength(50);

                entity.Property(e => e.Number).HasMaxLength(10);

                entity.Property(e => e.PostalCode).HasMaxLength(15);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Address_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Alpha2Code)
                    .HasName("UC_Country_Alpha2Code")
                    .IsUnique();

                entity.Property(e => e.Alpha2Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Alpha3Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NameTranslationKey)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.Alpha2Code)
                    .IsUnique();

                entity.HasIndex(e => e.Alpha3Code)
                    .IsUnique();

                entity.Property(e => e.Alpha2Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Alpha3Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NameTranslationKey)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NativeName)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasIndex(e => e.ServiceId)
                    .HasName("IX_Location_Service");

                entity.Property(e => e.Bed)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.PublicId).HasDefaultValueSql("newid()");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Service");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.ExternalId)
                    .IsUnique();

                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_Physician_Language");

                entity.HasIndex(e => e.NationalityId)
                    .HasName("IX_Physician_Country");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ExternalId).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.NationalId).HasMaxLength(50);

                entity.Property(e => e.PublicId).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Patient_Language");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Patient_Country");
            });

            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("IX_PatientAddress_Address")
                    .IsUnique();

                entity.HasIndex(e => e.PatientId)
                    .HasName("IX_PatientAddress_Patient")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Address)
                    .WithOne(p => p.PatientAddress)
                    .HasForeignKey<PatientAddress>(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAddress_Address");

                entity.HasOne(d => d.Patient)
                    .WithOne(p => p.PatientAddress)
                    .HasForeignKey<PatientAddress>(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientAddress_Patient");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ExternalId).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MedicalLicenseId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.NationalId).HasMaxLength(50);

                entity.Property(e => e.PublicId).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Physician)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Physician_Language");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Physician)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Physician_Country");
            });

            modelBuilder.Entity<PhysicianAddress>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("IX_PhysicianAddress_Address");

                entity.HasIndex(e => e.PhysicianId)
                    .HasName("IX_PhysicianAddress_Patient");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PhysicianAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicianAddress_Address");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.PhysicianAddress)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicianAddress_Patient");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Transition>(entity =>
            {
                entity.HasIndex(e => e.AdmittingPhysicianId)
                    .HasName("IX_Transition_Admitting_Physician");

                entity.HasIndex(e => e.AttendingPhysicianId)
                    .HasName("IX_Transition_Attending_Physician");

                entity.HasIndex(e => e.ConsultingPhysicianId)
                    .HasName("IX_Transition_Consulting_Physician");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Transition_Visit");

                entity.HasIndex(e => e.ReferringPhysicianId)
                    .HasName("IX_Transition_Referring_Physician");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.AdmittingPhysician)
                    .WithMany(p => p.TransitionAdmittingPhysician)
                    .HasForeignKey(d => d.AdmittingPhysicianId)
                    .HasConstraintName("FK_Transition_Admitting_Physician");

                entity.HasOne(d => d.AttendingPhysician)
                    .WithMany(p => p.TransitionAttendingPhysician)
                    .HasForeignKey(d => d.AttendingPhysicianId)
                    .HasConstraintName("FK_Transition_Attending_Physician");

                entity.HasOne(d => d.ConsultingPhysician)
                    .WithMany(p => p.TransitionConsultingPhysician)
                    .HasForeignKey(d => d.ConsultingPhysicianId)
                    .HasConstraintName("FK_Transition_Consulting_Physician");

                entity.HasOne(d => d.ReferringPhysician)
                    .WithMany(p => p.TransitionReferringPhysician)
                    .HasForeignKey(d => d.ReferringPhysicianId)
                    .HasConstraintName("FK_Transition_Referring_Physician");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.Transition)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transition_Visit");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasIndex(e => e.AdmittingPhysicianId);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublicId).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.AdmittingPhysician)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.AdmittingPhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Physician");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}