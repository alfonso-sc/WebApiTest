using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest.EntityModels;

public partial class BillingTimeContext : DbContext
{
    public BillingTimeContext()
    {
    }

    public BillingTimeContext(DbContextOptions<BillingTimeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Entry> Entries { get; set; }

    public virtual DbSet<FavoritesXref> FavoritesXrefs { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subproject> Subprojects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=54320;Database=billing_time;Username=postgres;Password=Pilar$2011");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Entry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entries_pkey");

            entity.ToTable("entries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Hours)
                .HasPrecision(4, 2)
                .HasColumnName("hours");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SubProjectId).HasColumnName("sub_project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.Entries)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entries_projects");

            entity.HasOne(d => d.SubProject).WithMany(p => p.Entries)
                .HasForeignKey(d => d.SubProjectId)
                .HasConstraintName("fk_entries_subprojects");

            entity.HasOne(d => d.User).WithMany(p => p.Entries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entries_users");
        });

        modelBuilder.Entity<FavoritesXref>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.SubProjectId, e.UserId }).HasName("favorites_xref_pkey");

            entity.ToTable("favorites_xref");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SubProjectId).HasColumnName("sub_project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.FavoritesXrefs)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_favorites_projects");

            entity.HasOne(d => d.SubProject).WithMany(p => p.FavoritesXrefs)
                .HasForeignKey(d => d.SubProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_favorites_subprojects");

            entity.HasOne(d => d.User).WithMany(p => p.FavoritesXrefs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_favorites_users");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.ChargingRate).HasColumnName("charging_rate");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.FixedBid)
                .HasDefaultValue(false)
                .HasColumnName("fixed_bid");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Company).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projects_companies");

            entity.HasOne(d => d.Manager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_projects_users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subproject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sub_projects_pkey");

            entity.ToTable("subprojects");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('sub_projects_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.EstimatedHours).HasColumnName("estimated_hours");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Project).WithMany(p => p.Subprojects)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("fk_subprojects_projects");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.ExpectedHours).HasColumnName("expected_hours");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesUsersXref",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_xref_roles"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_xref_users"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("roles_users_xref_pkey");
                        j.ToTable("roles_users_xref");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
