using amorphie.core.Base;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.core.Models.SignalR;
using amorphie.workflow.core.Models.Transfer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


class WorkflowDbContextFactory : IDesignTimeDbContextFactory<WorkflowDBContext>
{
    public WorkflowDBContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<WorkflowDBContext>();

        var connStr = "Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres;Include Error Detail=true;";
        builder.UseNpgsql(connStr);
        return new WorkflowDBContext(builder.Options);
    }
}

public class WorkflowDBContext : DbContext
{
    public DbSet<Workflow> Workflows { get; set; } = default!;
    public DbSet<WorkflowEntity> WorkflowEntities { get; set; } = default!;
    public DbSet<State> States { get; set; } = default!;
    public DbSet<StateToState> StateToStates { get; set; } = default!;
    public DbSet<Transition> Transitions { get; set; } = default!;
    public DbSet<Instance> Instances { get; set; } = default!;
    public DbSet<ZeebeMessage> ZeebeMessages { get; set; } = default!;
    public DbSet<InstanceTransition> InstanceTransitions { get; set; } = default!;
    public DbSet<InstanceEvent> InstanceEvents { get; set; } = default!;
    public DbSet<Page> Pages { get; set; } = default!;
    public DbSet<PageComponent> PageComponents { get; set; } = default!;
    public DbSet<PageComponentUiModel> PageComponentUiModels { get; set; } = default!;
    public DbSet<UiForm> UiForms { get; set; } = default!;
    public DbSet<FlowHeader> FlowHeaders { get; set; } = default!;
    public DbSet<TransferHistory> TransferHistories { get; set; } = default!;

    public DbSet<TransitionRole> TransitionRoles { get; set; } = default!;
    //Hub Data
    public DbSet<SignalRData> SignalRResponses { get; set; } = default!;
    //Zeebe Exporter DbSets

    public DbSet<Deployment> Deployments { get; set; } = default!;
    public DbSet<Incident> Incidents { get; set; } = default!;
    public DbSet<Job> Jobs { get; set; } = default!;
    public DbSet<JobBatch> JobBatchs { get; set; } = default!;
    public DbSet<Message> Messages { get; set; } = default!;
    public DbSet<MessageSubscription> MessageSubscriptions { get; set; } = default!;
    public DbSet<ProcessInstance> ProcessInstances { get; set; } = default!;
    public DbSet<Variable> Variables { get; set; } = default!;


    public WorkflowDBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Workflow>()
            .HasKey(w => w.Name);

        modelBuilder.Entity<ZeebeMessage>()
           .HasKey(w => w.Name);

        modelBuilder.Entity<WorkflowEntity>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<WorkflowEntity>()
            .HasOne(w => w.Workflow)
            .WithMany(w => w.Entities);

        modelBuilder.Entity<State>()
           .HasKey(s => s.Name)
           ;
        modelBuilder.Entity<State>()
               .HasOne(w => w.Workflow)
                 .WithMany(w => w.States);
        modelBuilder.Entity<State>()
            .Property(p => p.Kind).HasDefaultValue(StateKind.Default);

        modelBuilder.Entity<StateToState>()
               .HasOne(w => w.FromState)
                 .WithMany(w => w.FromStates)
                 .HasForeignKey(f => f.FromStateName)
                 ;
        // modelBuilder.Entity<StateToState>()
        //        .HasOne(w => w.ToState)
        //        .WithMany()
        //          .HasForeignKey(f => f.ToStateName)
        //          ;
        modelBuilder.Entity<StateToState>()
        .Property(p => p.IsDefault).HasDefaultValue(false);

        modelBuilder.Entity<Transition>()
           .HasKey(s => s.Name);

        modelBuilder.Entity<Page>()
          .HasKey(s => s.Id);
        modelBuilder.Entity<UiForm>()
          .HasKey(s => s.Id);
        modelBuilder.Entity<TransitionRole>()
        .HasKey(s => s.Id);

        modelBuilder.Entity<Instance>()
           .HasKey(s => s.Id);
        modelBuilder.Entity<PageComponent>()
      .HasKey(s => s.Id);
        modelBuilder.Entity<PageComponentUiModel>()
                 .HasKey(s => s.Id);
        modelBuilder.Entity<FlowHeader>()
          .HasKey(w => w.Key);


        modelBuilder.Entity<PageComponent>().HasIndex(item => item.SearchVector).HasMethod("GIN");
        modelBuilder.Entity<PageComponent>().Property(item => item.SearchVector).HasComputedColumnSql(FullTextSearchHelper.GetTsVectorComputedColumnSql("english", new[] { "PageName" }), true);
        modelBuilder.Entity<Instance>()
          .HasIndex("EntityName", "RecordId", "StateName");

        modelBuilder.Entity<Workflow>().HasIndex(item => item.SearchVector).HasMethod("GIN");
        modelBuilder.Entity<Workflow>().Property(item => item.SearchVector).HasComputedColumnSql(FullTextSearchHelper.GetTsVectorComputedColumnSql("english", new[] { "Name" }), true);

        modelBuilder.Entity<Instance>().HasIndex(item => item.SearchVector).HasMethod("GIN");
        modelBuilder.Entity<Instance>().Property(item => item.SearchVector).HasComputedColumnSql(FullTextSearchHelper.GetTsVectorComputedColumnSql("english", new[] { "WorkflowName", "ZeebeFlowName", "EntityName", "StateName" }), true);



        modelBuilder.Entity<InstanceTransition>()
           .HasKey(s => s.Id);

        modelBuilder.Entity<InstanceEvent>()
         .HasKey(s => s.Id);

        modelBuilder.Entity<Transition>()
            .HasOne(s => s.FromState)
            .WithMany(s => s.Transitions);


        // Translation Relations
        modelBuilder.Entity<Translation>().Property<string>("StateName_Title");
        modelBuilder.Entity<Translation>().Property<string>("StateName_Description");
        modelBuilder.Entity<Translation>().Property<string>("StateName_PublicForm");

        modelBuilder.Entity<State>()
            .HasMany<Translation>(t => t.Titles)
            .WithOne()
            .HasForeignKey("StateName_Title");

        modelBuilder.Entity<State>()
            .HasMany<Translation>(t => t.Descriptions)
            .WithOne()
            .HasForeignKey("StateName_Description");
        modelBuilder.Entity<State>()
            .HasMany<Translation>(t => t.PublicForms)
            .WithOne()
            .HasForeignKey("StateName_PublicForm");

        modelBuilder.Entity<Translation>().Property<string>("WorkflowName_Title");

        modelBuilder.Entity<Workflow>()
            .HasMany<Translation>(t => t.Titles)
            .WithOne()
            .HasForeignKey("WorkflowName_Title");

        modelBuilder.Entity<Translation>().Property<string>("WorkflowName_HistoryForm");

        modelBuilder.Entity<Workflow>()
            .HasMany<Translation>(t => t.HistoryForms)
            .WithOne()
            .HasForeignKey("WorkflowName_HistoryForm");

        modelBuilder.Entity<Translation>().Property<string>("TransitionName_Title");
        modelBuilder.Entity<Translation>().Property<string>("TransitionName_Form");
        modelBuilder.Entity<Translation>().Property<string>("TransitionName_Page");
        modelBuilder.Entity<Translation>().Property<string>("TransitionName_HistoryForm");


        modelBuilder.Entity<Transition>()
            .HasMany<Translation>(t => t.Titles)
            .WithOne()
            .HasForeignKey("TransitionName_Title");

        modelBuilder.Entity<Transition>()
           .HasMany<Translation>(t => t.Forms)
           .WithOne()
           .HasForeignKey("TransitionName_Form");

        modelBuilder.Entity<Transition>()
           .HasMany<Translation>(t => t.Pages)
           .WithOne()
           .HasForeignKey("TransitionName_Page");

        modelBuilder.Entity<Transition>()
           .HasMany<Translation>(t => t.HistoryForms)
           .WithOne()
           .HasForeignKey("TransitionName_HistoryForm");

        modelBuilder.Entity<Translation>().Property<Guid?>("PageId_Page");
        modelBuilder.Entity<Page>()
           .HasMany<Translation>(t => t.Pages)
           .WithOne()
           .HasForeignKey("PageId_Page");


        modelBuilder.Entity<Translation>().Property<Guid?>("UiForm_Id");

        modelBuilder.Entity<UiForm>()
           .HasMany<Translation>(t => t.Forms)
           .WithOne()
           .HasForeignKey("UiForm_Id");


        modelBuilder.Entity<TransferHistory>().ToTable("TransferHistories", "transfer")
        .HasKey(p => p.Id);


        // modelBuilder.SeedUserResetPassword();
        // modelBuilder.SeedUserLifecycle();

        //modelBuilder.SeedRetailLoanWorkflow();



        //Zeebe Exporter Tables

        modelBuilder.Entity<Deployment>().ToTable("Deployments", "exporter")
        .HasKey(p => p.ResourceName);

        modelBuilder.Entity<Incident>().ToTable("Incidents", "exporter")
        .HasKey(p => p.Key);

        modelBuilder.Entity<Job>().ToTable("Jobs", "exporter")
        .HasKey(p => p.Key);
        modelBuilder.Entity<JobBatch>().ToTable("JobBatchs", "exporter")
        .HasKey(p => new { p.Key, p.ElementInstanceKey });

        modelBuilder.Entity<Message>().ToTable("Messages", "exporter")
        .HasKey(p => p.Id);
        modelBuilder.Entity<Message>()
        .Property(p => p.Variables)
        .HasColumnType("jsonb");

        modelBuilder.Entity<MessageSubscription>().ToTable("MessageSubscriptions", "exporter")
        .HasKey(p => p.Id);

        modelBuilder.Entity<MessageSubscription>()
        .Property(p => p.Variables)
        .HasColumnType("jsonb");

        modelBuilder.Entity<Process>().ToTable("Process", "exporter")
        .HasKey(p => p.Key);

        modelBuilder.Entity<ProcessInstance>().ToTable("ProcessInstances", "exporter")
        .HasKey(p => p.Key);


        modelBuilder.Entity<Variable>().ToTable("Variables", "exporter")
            .HasKey(p => p.Key);
        //Hub Data
        modelBuilder.Entity<SignalRData>().ToTable("SignalRResponses", "signalrdata")
            .HasKey(p => p.Id);

    }
}
