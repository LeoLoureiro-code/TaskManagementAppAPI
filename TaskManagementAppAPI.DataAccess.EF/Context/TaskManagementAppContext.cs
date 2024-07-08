using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskManagementAppAPI.DataAccess.EF.Models;

namespace TaskManagementAppAPI.DataAccess.EF.Context;

public partial class TaskManagementAppContext : DbContext
{
    public TaskManagementAppContext()
    {
    }

    public TaskManagementAppContext(DbContextOptions<TaskManagementAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TaskManagementApp;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("UserTasks");

            entity.Property(e => e.Subtasks)
                .IsUnicode(false)
                .HasColumnName("subtasks");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("taskDescription");
            entity.Property(e => e.TaskId)
                .ValueGeneratedOnAdd()
                .HasColumnName("taskID");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taskStatus");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taskTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
