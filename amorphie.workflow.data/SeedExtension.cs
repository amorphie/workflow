using Microsoft.EntityFrameworkCore;

public static class SeedExtension
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "retail-loan",
            Tags = new[] { "retail", "loan" },
            Type = WorkflowType.Zeebe,
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
            Tags = new[] { "retail", "loan","retail-loan" },
            Type = StateType.Start,
            BaseStatus = BaseStatusType.New,

            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });



        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "user-lifecyle",
            Tags = new[] { "idm", "user" },
            Type = WorkflowType.StateMachine,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });

        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user-lifecyle", Label = "Kullanici Statu Akisi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user-lifecyle", Label = "User State Process", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
    }
}
