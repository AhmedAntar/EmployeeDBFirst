using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDBFirst.Models;

public partial class EmployeesDbContext : DbContext
{
    public EmployeesDbContext()
    {
    }

    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A96D989133E");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityNameArabic).HasMaxLength(250);
            entity.Property(e => e.CityNameEnglish).HasMaxLength(250);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD90C7482D");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentAbbr).HasMaxLength(250);
            entity.Property(e => e.DepartmentName).HasMaxLength(250);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1BD223715");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Dbo)
                .HasColumnType("date")
                .HasColumnName("DBO");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.HiringDate).HasColumnType("date");
            entity.Property(e => e.Salary).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.City).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Employee__CityID__286302EC");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
