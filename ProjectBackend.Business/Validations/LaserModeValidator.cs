using ProjectBackend.Business.DTOs;
using FluentValidation;

namespace ProjectBackend.Business.Validations
{
    public class LaserModeValidator : AbstractValidator<LaserModeDTO>
    {
        public LaserModeValidator()
        {
            RuleFor(x => x.LaserModeId)
                .LessThan(10000).WithMessage("Mode Code should not exceed 4 digits.");

            RuleFor(x => x.ModeInfo).Length(0,5000)
                .WithMessage("Mode information should not exceed 5000 characters.");

            RuleFor(x => x.ModePRI).InclusiveBetween(0, 1000000)
                .WithMessage("Mode PRI should be between [0, 1000000].");

            RuleFor(x => x.ModePulseDuration).InclusiveBetween(0, 1000000)
                .WithMessage("Mode Pulse Duration should be between [0, 1000000].");    

            RuleFor(x => x.ScanPeriod).InclusiveBetween(0, 1000)
                .WithMessage("Scan Period should be between [0, 1000].");
        }
    }
    
}

