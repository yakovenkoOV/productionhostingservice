using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ApplicationDbContext : DbContext
{
    //dbset 
    public DbSet<ProductionFacility> ProductionFacilities { get; set; }
    public DbSet<ProcessEquipmentType> ProcessEquipmentTypes { get; set; }
    public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is ProductionFacility || e.Entity is ProcessEquipmentType || e.Entity is EquipmentPlacementContract);

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                entry.Property("UpdatedAt").CurrentValue = now;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Налаштування ProductionFacility
        modelBuilder.Entity<ProductionFacility>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.StandardArea)
                .IsRequired();

            // Унікальний індекс на поле Code
            entity.HasIndex(e => e.Code)
                .IsUnique().HasDatabaseName("IX_ProductionFacility_Code");

            // Поля аудиту
            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.Property(e => e.UpdatedAt)
                .IsRequired();
        });

        // Налаштування ProcessEquipmentType
        modelBuilder.Entity<ProcessEquipmentType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Area)
                .IsRequired();

            // Унікальний індекс на поле Code
            entity.HasIndex(e => e.Code)
                .IsUnique().HasDatabaseName("IX_ProcessEquipmentType_Code");

            // Поля аудиту
            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.Property(e => e.UpdatedAt)
                .IsRequired();
        });

        // Налаштування EquipmentPlacementContract
        modelBuilder.Entity<EquipmentPlacementContract>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.EquipmentQuantity)
                .IsRequired();

            entity.HasOne(e => e.ProductionFacility)
                .WithMany(pf => pf.Contracts)
                .HasForeignKey(e => e.ProductionFacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ProcessEquipmentType)
                .WithMany(pet => pet.Contracts)
                .HasForeignKey(e => e.ProcessEquipmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Поля аудиту
            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.Property(e => e.UpdatedAt)
                .IsRequired();
        });

        var fixedDate = new DateTime(2024, 12, 06, 0, 0, 0, DateTimeKind.Utc);
        // Додаємо 10 записів для ProductionFacility
        modelBuilder.Entity<ProductionFacility>().HasData(
            new ProductionFacility { Id = 1, Code = "PF001", Name = "Фабрика 1", StandardArea = 1000, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 2, Code = "PF002", Name = "Фабрика 2", StandardArea = 1200, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 3, Code = "PF003", Name = "Фабрика 3", StandardArea = 1500, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 4, Code = "PF004", Name = "Фабрика 4", StandardArea = 2000, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 5, Code = "PF005", Name = "Фабрика 5", StandardArea = 1800, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 6, Code = "PF006", Name = "Фабрика 6", StandardArea = 2200, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 7, Code = "PF007", Name = "Фабрика 7", StandardArea = 2500, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 8, Code = "PF008", Name = "Фабрика 8", StandardArea = 3000, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 9, Code = "PF009", Name = "Фабрика 9", StandardArea = 3500, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProductionFacility { Id = 10, Code = "PF010", Name = "Фабрика 10", StandardArea = 4000, CreatedAt = fixedDate, UpdatedAt = fixedDate }
        );

        // Додаємо 10 записів для ProcessEquipmentType
        modelBuilder.Entity<ProcessEquipmentType>().HasData(
            new ProcessEquipmentType { Id = 1, Code = "PET001", Name = "Обладнання 1", Area = 50, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 2, Code = "PET002", Name = "Обладнання 2", Area = 75, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 3, Code = "PET003", Name = "Обладнання 3", Area = 60, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 4, Code = "PET004", Name = "Обладнання 4", Area = 80, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 5, Code = "PET005", Name = "Обладнання 5", Area = 100, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 6, Code = "PET006", Name = "Обладнання 6", Area = 45, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 7, Code = "PET007", Name = "Обладнання 7", Area = 110, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 8, Code = "PET008", Name = "Обладнання 8", Area = 65, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 9, Code = "PET009", Name = "Обладнання 9", Area = 90, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new ProcessEquipmentType { Id = 10, Code = "PET010", Name = "Обладнання 10", Area = 120, CreatedAt = fixedDate, UpdatedAt = fixedDate }
        );
    }

}