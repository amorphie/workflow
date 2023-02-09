using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amorphie.tag.data;

class WorkflowDbContextFactory : IDesignTimeDbContextFactory<WorkflowDBContext>
{
    public WorkflowDBContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<WorkflowDBContext>();

        var connStr = "Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres";
        builder.UseNpgsql(connStr);
        return new WorkflowDBContext(builder.Options);
    }
}

public class WorkflowDBContext : DbContext
{
    public DbSet<Workflow>? Workflows { get; set; }

    public WorkflowDBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Workflow>()
            .HasKey(w => w.Name);

        modelBuilder.Entity<WorkflowEntity>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<State>()
           .HasKey(s => s.Name);

        modelBuilder.Entity<Transition>()
           .HasKey(s => s.Name);

        modelBuilder.Entity<Transition>()
           .HasOne(s => s.FromState)
           .WithMany(s => s.Transitions);


        // Translation Relations
        modelBuilder.Entity<Translation>().Property<string>("StateName_Title");
        modelBuilder.Entity<Translation>().Property<string>("StateName_Description");

        modelBuilder.Entity<State>()
            .HasMany<Translation>(t => t.Title)
            .WithOne()
            .HasForeignKey("StateName_Title");

        modelBuilder.Entity<State>()
            .HasMany<Translation>(t => t.Description)
            .WithOne()
            .HasForeignKey("StateName_Description");

        modelBuilder.Entity<Translation>().Property<string>("WorkflowName_Title");

        modelBuilder.Entity<Workflow>()
            .HasMany<Translation>(t => t.Titles)
            .WithOne()
            .HasForeignKey("WorkflowName_Title");

        modelBuilder.Entity<Translation>().Property<string>("WorkflowName_Transition");

        modelBuilder.Entity<Transition>()
            .HasMany<Translation>(t => t.Title)
            .WithOne()
            .HasForeignKey("WorkflowName_Transition");

        modelBuilder.SeedRetailLoanWorkflow();
        modelBuilder.SeedUserLifecycle();
    }
}
