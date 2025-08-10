using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Shared.Models;

namespace TodoApp.Shared.Data;

public class AppDbContext : DbContext
{

    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=127.0.0.1;initial catalog=todo-db;persist security info=True;TrustServerCertificate=True; user id=sa;password=Abc@1234;MultipleActiveResultSets=True;Max Pool Size=200;");
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("LK_Categories", "dbo");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();

            entity.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

            entity.Property(c => c.Description)
          .HasColumnType("nvarchar(500)");

            entity.Property(c => c.IsActive)
            .HasDefaultValue(false);

            entity.HasMany(c => c.Items)
            .WithOne(i => i.Category)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                new { Id = 1, Name = "Personal", Description = "Personal" },
                new { Id = 2, Name = "Work", Description ="Work" },
                new { Id = 3, Name = "Others", Description = "Others" }

                );
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.ToTable("ToDoItems", "dbo");
            entity.HasKey(c => c.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.Property(e => e.CreatedDate)
            .HasColumnName("created_date")
            .HasColumnType("datetime")
            .HasDefaultValueSql("GetDate()");

            entity.Property(e => e.UpdatedDate)
           .HasColumnType("datetime");

            entity.Property(e => e.Status)
            .HasColumnType("smallint")
            .HasDefaultValue(TodoItemStatus.New);

        });
    }
}
