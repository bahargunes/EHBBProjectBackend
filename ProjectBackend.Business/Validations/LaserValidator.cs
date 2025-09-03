using ProjectBackend.Business.DTOs;
using FluentValidation;

namespace ProjectBackend.Business.Validations
{
    public class LaserValidator : AbstractValidator<LaserDTO>
    {
        public LaserValidator()
        {
            RuleFor(x => x.LaserName).NotEmpty().WithMessage("Laser name can't be empty.")
                .Length(1, 400).WithMessage("Laser name should not exceed 400 charaters.");

            RuleFor(x => x.SpotNumber).Length(0, 5).WithMessage("Spot number should not exceed 5 digits.");

            RuleFor(x => x.Weight).InclusiveBetween(0, 1000).WithMessage("Weight should be between [0, 1000]");

            RuleFor(x => x.OperatingTemperature).InclusiveBetween(-100, 100)
                .WithMessage("Operating temperature should be between [-100, 100]");

            RuleFor(x => x.StorageTemperature).InclusiveBetween(-100, 100)
                .WithMessage("Storage temperature should be between [-100, 100]");

            RuleFor(x => x.Power).InclusiveBetween(0, 100000)
                .WithMessage("Power should be between [0, 100000]");

            RuleForEach(x => x.LaserModes).SetValidator(new LaserModeValidator());

        }
    }

}
