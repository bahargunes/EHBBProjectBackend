
using ProjectBackend.Business.DTOs;
using FluentValidation;

namespace ProjectBackend.Business.Validations
{
    public class EmitterValidator : AbstractValidator<EmitterDTO>
    {
        public EmitterValidator()
        {
            RuleFor(x => x.Notation)
                        .Length(0,5)
                        .WithMessage("Notatiton should not exceed 5 characters.");


            RuleFor(x => x.EmitterName).NotEmpty().WithMessage("Emitter name can't be empty.")
                                        .MaximumLength(100)
                                        .WithMessage("Emitter name should not exceed 100 characters.");

            //nvarchar / (100)
            RuleFor(x => x.Function).NotEmpty().WithMessage("Function can't be empty.")
                                        .MaximumLength(100)
                                        .WithMessage("Function should not exceed 100 characters.");

            RuleFor(x => x.Description).MaximumLength(50)
                                        .WithMessage("Emitter description should not exceed 50 characters.");



            RuleFor(x => x.SpotNo).NotEmpty().WithMessage("Spot no can't be empty.")
                                        .MaximumLength(25).WithMessage("Spot no should not exceed 25 characters.");



            RuleForEach(x => x.Modes).SetValidator(new EmitterModeValidator());

        }


        
    }

}
