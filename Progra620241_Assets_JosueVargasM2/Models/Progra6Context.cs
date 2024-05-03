﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Progra620241_Assets_JosueVargasM2.Models;

public partial class Progra6Context : DbContext
{
    public Progra6Context()
    {
    }

    public Progra6Context(DbContextOptions<Progra6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Depreciation> Depreciations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:azurejosue.database.windows.net,1433;Initial Catalog=Progra6;Persist Security Info=False;User ID=CloudSA32c1bfb5;Password=Josuevm1701;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__4349237201E7F3DE");

            entity.ToTable("Asset");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AcquisitionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.AssetCategoryId).HasColumnName("AssetCategoryID");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepreciationId).HasColumnName("DepreciationID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AssetCategory).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAsset582798");

            entity.HasOne(d => d.Department).WithMany(p => p.Assets)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAsset220328");

            entity.HasOne(d => d.Depreciation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.DepreciationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAsset922702");

            entity.HasOne(d => d.User).WithMany(p => p.Assets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAsset855199");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.AssetCategoryId).HasName("PK__AssetCat__C381F49D93719493");

            entity.ToTable("AssetCategory");

            entity.Property(e => e.AssetCategoryId).HasColumnName("AssetCategoryID");
            entity.Property(e => e.AssetCategoryDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDE1D18646");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Depreciation>(entity =>
        {
            entity.HasKey(e => e.DepreciationId).HasName("PK__Deprecia__DEEBFE2958F06393");

            entity.ToTable("Depreciation");

            entity.Property(e => e.DepreciationId).HasColumnName("DepreciationID");
            entity.Property(e => e.ByMonth)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.ByYear)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.DepreciationName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 5)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACD7E47D5C");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CardId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser854768");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55200E3827");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserRoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
