using Microsoft.EntityFrameworkCore;

public static class SeedExtension
{
    public static void SeedUserLifecycle(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "user-lifecyle",
            Tags = new[] { "idm", "user" },
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });

        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-lifecyle", Label = "Kullanici Statu Akisi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-lifecyle", Label = "User State Process", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<WorkflowEntity>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user-lifecyle", Name = "user", IsExclusive = false, IsStateManager = true,  AvailableInStatus = BaseStatusType.All, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
    }

    public static void SeedUserResetPassword(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ZeebeFlow>().HasData(new { Name = "zb-user-reset-password", Tags = new[] { "idm", "user", "security" }, IsAtomic = false, IsStateManager = false, Process = "", Gateway = "" });

        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "user-reset-password",
            Tags = new[] { "idm", "user", "security" },
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });

        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-reset-password", Label = "Kullanici sifre yenileme", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-reset-password", Label = "User Password Reset", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<WorkflowEntity>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user-reset-password", Name = "user", IsExclusive = false, IsStateManager = true, AvailableInStatus = BaseStatusType.All, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
    }



    public static void SeedRetailLoanWorkflow(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "retail-loan",
            Tags = new[] { "retail", "loan" },
            ProcessName = "retail-loan-workflow",
            Process = "<bpmn:definitions>...</bpmn:definitions>",
            Gateway = "http://localhost:26500",
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "retail-loan", Label = "Bireysel Kredi Sureci", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "retail-loan", Label = "Retail Loan Process", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "retail-loan",
            Name = "retail-loan-start",
            Tags = new[] { "retail", "loan", "retail-loan" },
            Type = StateType.Start,
            BaseStatus = BaseStatusType.New,

            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "retail-loan-start", Label = "Akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "retail-loan-start", Label = "Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "retail-loan-start", Label = "Kredi sureci akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "retail-loan-start", Label = "Retail Loan Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "retail-loan",
            Name = "retail-loan-finish",
            Tags = new[] { "retail", "loan", "retail-loan" },
            Type = StateType.Finish,
            BaseStatus = BaseStatusType.New,

            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "retail-loan-finish", Label = "Akis bitis asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "retail-loan-finish", Label = "Finish state", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "retail-loan-finish", Label = "Kredi sureci akis bitis asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "retail-loan-finish", Label = "Retail loan finis state", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
    }
}
