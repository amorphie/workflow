﻿using amorphie.core.Base;
using amorphie.core.Enums;
using Microsoft.EntityFrameworkCore;

public static class SeedExtension
{
    public static void SeedUserLifecycle(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ZeebeMessage>().HasData(new { Name = "user-register", Tags = new[] { "idm", "user" }, Process = "User_Register", Message = "user-register", Gateway = "zeebe-local", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<ZeebeMessage>().HasData(new { Name = "user-registration-approve", Tags = new[] { "idm", "user" }, Process = "User_Register", Message = "user-registration-approve", Gateway = "zeebe-local", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<ZeebeMessage>().HasData(new { Name = "user-registration-aml-approve", Tags = new[] { "idm", "user" }, Process = "User_Register", Message = "user-registration-aml-approve", Gateway = "zeebe-local", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<ZeebeMessage>().HasData(new { Name = "user-registration-aml-reject", Tags = new[] { "idm", "user" }, Process = "User_Register", Message = "user-registration-aml-reject", Gateway = "zeebe-local", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Workflow>().HasData(new { Name = "user", Tags = new[] { "idm", "user" }, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user", Label = "Kullanici Statu Akisi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user", Label = "User State Process", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<WorkflowEntity>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user", Name = "user", AllowOnlyOneActiveInstance = false, IsStateManager = true, AvailableInStatus = StatusType.All, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-start", Tags = new[] { "user", "security", "idm" }, Type = StateType.Start, BaseStatus = StatusType.New, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-start", Label = "Akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-start", Label = "Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-start", Label = "Akis baslangic asama aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-start", Label = "Start state description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-approval", Tags = new[] { "user", "security", "idm" }, Type = StateType.Standart, BaseStatus = StatusType.New, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-approval", Label = "Kullanici Onay Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-approval", Label = "User Approval State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-approval", Label = "Kullanici onay aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-approval", Label = "User approval description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-aml-approval", Tags = new[] { "user", "security", "idm" }, Type = StateType.Standart, BaseStatus = StatusType.New, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-aml-approval", Label = "AML Onay Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-aml-approval", Label = "AML Approval State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-aml-approval", Label = "AML onay asama aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-aml-approval", Label = "AML approval description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-active", Tags = new[] { "user", "security", "idm" }, Type = StateType.Standart, BaseStatus = StatusType.Active, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-active", Label = "Akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-active", Label = "Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-active", Label = "Akis baslangic asama aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-active", Label = "Start state description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-suspended", Tags = new[] { "user", "security", "idm" }, Type = StateType.Standart, BaseStatus = StatusType.Passive, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-suspended", Label = "Akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-suspended", Label = "Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-suspended", Label = "Akis baslangic asama aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-suspended", Label = "Start state description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new { WorkflowName = "user", Name = "user-deactivated", Tags = new[] { "user", "security", "idm" }, Type = StateType.Standart, BaseStatus = StatusType.Passive, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-deactivated", Label = "Kayit deaktif", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-deactivated", Label = "Deactivated", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-deactivated", Label = "Kayit deaktive edilmis", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-deactivated", Label = "Record has been deactivated", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-start", ToStateName = "user-approval", Name = "user-register", FlowName = "user-register", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-register", Label = "Kullanici Kaydi Onayla", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-register", Label = "User Registration Approve", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-register", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-register", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });


        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-approval", ToStateName = "user-aml-approval", Name = "user-registration-approve", FlowName = "user-registration-approve", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-approve", Label = "Kullanici Kaydi Tamamla", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-approve", Label = "Register User", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-approve", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-approve", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-aml-approval", ToStateName = "user-active", Name = "user-registration-aml-approve", FlowName = "user-registration-aml-approve", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-aml-approve", Label = "Kullanici AML Onay", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-aml-approve", Label = "User AML Approve", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-aml-approve", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-aml-approve", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-aml-approval", ToStateName = "user-deactivated", Name = "user-registration-aml-reject", FlowName = "user-registration-aml-reject", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-aml-reject", Label = "Kullanici AML Ret", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-registration-aml-reject", Label = "User AML Reject", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-aml-reject", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-registration-aml-reject", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-active", ToStateName = "user-suspended", Name = "user-suspend", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-suspend", Label = "Kullanici Gecici Kitle", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-suspend", Label = "Suspend User", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-suspend", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-suspend", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-active", ToStateName = "user-deactivated", Name = "user-deactive", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-deactive", Label = "Kullanici Pasif Yap", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-deactive", Label = "Deactive User", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-deactive", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-deactive", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-suspended", ToStateName = "user-active", Name = "user-activate-fs", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-activate-fs", Label = "Kullanici Pasif Yap", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-activate-fs", Label = "Deactive User", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-activate-fs", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-activate-fs", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-deactivated", ToStateName = "user-active", Name = "user-activate-fd", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-activate-fd", Label = "Kullanici Aktif Yap", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-activate-fd", Label = "Activate User", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-activate-fd", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-activate-fd", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
    }

    public static void SeedUserResetPassword(this ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<ZeebeFlow>().HasData(new { Name = "zb-user-reset-password", Tags = new[] { "idm", "user", "security" }, IsAtomic = false, IsStateManager = false, Process = "<bpmn:process></bpmn:process>", Gateway = "https://127.0.0.1", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Workflow>().HasData(new
        {
            Name = "user-reset-password",
            //ZeebeFlowName = "zb-user-reset-password",
            Tags = new[] { "idm", "user", "security" },
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });

        modelBuilder.Entity<WorkflowEntity>().HasData(new { Id = Guid.NewGuid(), WorkflowName = "user-reset-password", Name = "user", AllowOnlyOneActiveInstance = false, IsStateManager = false, AvailableInStatus = StatusType.All, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-reset-password", Label = "Kullanici sifre yenileme", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), WorkflowName_Title = "user-reset-password", Label = "User Password Reset", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "user-reset-password",
            Name = "user-reset-password-start",
            Tags = new[] { "user", "idm", "security" },
            Type = StateType.Start,
            BaseStatus = StatusType.InProgress,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-start", Label = "Akis Baslangic Asamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-start", Label = "Start State", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-start", Label = "Akis baslangic asama aciklamasi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-start", Label = "Start state description", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "user-reset-password",
            Name = "user-reset-password-card-password-valid",
            Tags = new[] { "user", "loan", "security" },
            Type = StateType.Standart,
            BaseStatus = StatusType.InProgress,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-card-password-valid", Label = "Kart Sifresi Dogru", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-card-password-valid", Label = "Card Pass Valid", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-card-password-valid", Label = "Kart Sifresi dogru, sifre belirleme bekleniyor", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-card-password-valid", Label = "Card password valid, set password.", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "user-reset-password",
            Name = "user-reset-password-security-question-valid",
            Tags = new[] { "user", "loan", "security" },
            Type = StateType.Standart,
            BaseStatus = StatusType.InProgress,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-security-question-valid", Label = "Guvenlik Sorusu Dogru", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-security-question-valid", Label = "Security Question Valid", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-security-question-valid", Label = "Guvenlik Sorusu dogru, sifre belirleme bekleniyor", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-security-question-valid", Label = "Security question valid, set password.", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });



        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "user-reset-password",
            Name = "user-reset-password-set",
            Tags = new[] { "user", "loan", "security" },
            Type = StateType.Finish,
            BaseStatus = StatusType.Completed,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-set", Label = "Sifre Degisti", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-set", Label = "Password Was Reset", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-set", Label = "Sifre guncellendi ve akis tamamlandi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-set", Label = "Password was reset and flow completed.", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<State>().HasData(new
        {
            WorkflowName = "user-reset-password",
            Name = "user-reset-password-fail",
            Tags = new[] { "user", "loan", "security" },
            Type = StateType.Finish,
            BaseStatus = StatusType.Completed,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            CreatedBy = Guid.Empty,
            ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            ModifiedBy = Guid.Empty
        });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-fail", Label = "Kart veya Guvenlik Sorusu Dogrulanamadi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Title = "user-reset-password-fail", Label = "Card Pass Or Security Question Not Valid", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-fail", Label = "Sifre guncellenemedi ve akis tamamlandi", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), StateName_Description = "user-reset-password-fail", Label = "Password was NOT reset and flow completed.", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });


        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-reset-password-start", Name = "user-reset-password-validate-with-card", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-validate-with-card", Label = "Kart Sifresi Ile Yenile", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-validate-with-card", Label = "Reset By Card Pin", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-validate-with-card", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-validate-with-card", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-reset-password-start", Name = "user-reset-password-validate-with-security-question", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-validate-with-security-question", Label = "Guvenlik Sorusu Ile Yenile", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-validate-with-security-question", Label = "Reset By Security Question", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-validate-with-security-question", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-validate-with-security-question", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-reset-password-card-password-valid", Name = "user-reset-password-set-password-acp", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-set-password-acp", Label = "Sifre Belirle", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-set-password-acp", Label = "Set New Password", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-set-password-acp", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-set-password-acp", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });

        modelBuilder.Entity<Transition>().HasData(new { FromStateName = "user-reset-password-security-question-valid", Name = "user-reset-password-set-password-asq", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-set-password-asq", Label = "Sifre Belirle", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Title = "user-reset-password-set-password-asq", Label = "Set New Password", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-set-password-asq", Label = @"{ ""display"": ""form"" ...tr components... }", Language = "tr-TR", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
        modelBuilder.Entity<Translation>().HasData(new { Id = Guid.NewGuid(), TransitionName_Form = "user-reset-password-set-password-asq", Label = @"{ ""display"": ""form"" ...en components... }", Language = "en-EN", CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), CreatedBy = Guid.Empty, ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), ModifiedBy = Guid.Empty });
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
            BaseStatus = StatusType.New,

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
            BaseStatus = StatusType.New,

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
