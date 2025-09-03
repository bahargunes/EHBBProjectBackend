using ProjectBackend.Business.DTOs;
using FluentValidation;

namespace ProjectBackend.Business.Validations
{
    public class EmitterModeValidator : AbstractValidator<EmitterModeDTO>
    {
        public EmitterModeValidator() 
        {
            RuleFor(x => x.ModeName).NotNull().WithMessage("Mode name cannot be empty.")
                .MaximumLength(50)
                .WithMessage("Mode name should not exceed 50 characters.");

            RuleFor(x => x.RFLimits).NotNull().WithMessage("RF Limits cannot be empty.")
                .InclusiveBetween(0, 100000)
                .WithMessage("RF Limits should be between [0, 100000].");

            RuleFor(x => x.PRILimits).NotNull().WithMessage("PRI Limits cannot be empty.")
                .InclusiveBetween(0, 100000)
                .WithMessage("PRI Limits should be between [0, 100000].");

            RuleFor(x => x.PDLimits).NotNull().WithMessage("PD Limits cannot be empty.")
                .InclusiveBetween(0, 100000)
                .WithMessage("PD Limits should be between [0, 100000].");

            RuleFor(x => x.ScanLimits).NotNull().WithMessage("Scan Limits cannot be empty.")
            .InclusiveBetween(0, 1000)
                .WithMessage("Scan Limits should be between [0, 10000].");

        }

    }
}
