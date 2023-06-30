using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public class WorkTaskContext : DbContext
{
    public WorkTaskContext(DbContextOptions<WorkTaskContext> options) : base(options) { }

    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<WorkActivity> WorkActivities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<WorkTaskCategory> TasksCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<WorkActivity>()
            .HasOne(a => a.WorkTask)
            .WithMany(t => t.Activities)
            .HasForeignKey(a => a.WorkTaskId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<WorkTaskCategory>()
            .HasKey(tc => new { tc.WorkTaskId, tc.CategoryId });

        modelBuilder
            .Entity<WorkTaskCategory>()
            .HasOne(tc => tc.WorkTask)
            .WithMany(wt => wt.WorkTaskCategories)
            .HasForeignKey(w => w.WorkTaskId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<WorkTaskCategory>()
            .HasOne(tc => tc.Category)
            .WithMany(wt => wt.WorkTaskCategories)
            .HasForeignKey(w => w.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<Category>()
            .HasIndex(c => c.Title)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}

