﻿using System;
using System.Collections.Generic;
using EmpApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpApp.DataAccess;

public partial class NgIpfDBContext : DbContext
{
    public NgIpfDBContext()
    {
    }

    public NgIpfDBContext(DbContextOptions<NgIpfDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Emplyee_DB;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Emp_Id).HasName("Employee_pkey");

            entity.Property(e => e.Emp_Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
