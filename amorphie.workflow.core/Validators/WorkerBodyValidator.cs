using amorphie.workflow.core.Dtos;
using FluentValidation;

public sealed class WorkerBodyValidator : AbstractValidator<WorkerBody>
{
    public WorkerBodyValidator()
    {
        RuleFor(x => x.LastTransition).NotNull().NotEmpty();
        RuleFor(x => x.InstanceId).NotNull().NotEmpty();
        RuleFor(x => x.Headers).Cascade(CascadeMode.Stop).NotNull().SetValidator(new WorkerBodyHeadersValidator());
        //RuleFor(x => x.BodyHeaders).SetValidator(new WorkerBodyHeadersValidator());
        //RuleFor(x => x.BodyHeaders.XTokenId).NotNull().NotEmpty();
        //RuleFor(x => x.BodyHeaders.XDeviceId).NotNull().NotEmpty();
    }
}

public sealed class WorkerBodyHeadersValidator : AbstractValidator<WorkerBodyHeaders>
{
    public WorkerBodyHeadersValidator()
    {
        RuleFor(x => x.XTokenId).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        RuleFor(x => x.XDeviceId).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
    }
}