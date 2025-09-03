using ProjectBackend.Business.DTOs;
using FluentValidation;

namespace ProjectBackend.Business.Validations
{
    public class PlatformValidator : AbstractValidator<PlatformDTO>
    {
        public PlatformValidator()
        {
            RuleFor(x => x.PlatformName).Length(0, 50).WithMessage("Platform name should not exceed 50 charathers.");

            RuleFor(x => x.PlatformType)
            .IsInEnum()
            .WithMessage("Please select a valid platform type.");

            RuleFor(x => x.PlatformCategory)
                .IsInEnum()
                .WithMessage("Please select a valid platform category.");

            RuleFor(x => x)
            .Must(HaveValidPlatformTypeAndCategoryRelationship)
            .WithMessage("Platform category does not match the selected platform type.");

            RuleFor(x => x.Remarks).Length(0,400).WithMessage("Remarks should not exceed 400 characters.");

            RuleFor(x => x.Lenght).NotNull().WithMessage("Lenght cannot be empty");
            RuleFor(x => x.Width).NotNull().WithMessage("Width cannot be empty");
            RuleFor(x => x.Height).NotNull().WithMessage("Height cannot be empty");
            RuleFor(x => x.Weight).NotNull().WithMessage("Weight cannot be empty");
            RuleFor(x => x.MaxSpeed).NotNull().WithMessage("Max Speed cannot be empty");
            RuleFor(x => x.MinSpeed).NotNull().WithMessage("Min Speed cannot be empty");


            RuleFor(x => x.Latitude).NotNull().WithMessage("Latitude cannot be empty")
                                .LessThanOrEqualTo(90)
                                .GreaterThanOrEqualTo(-90)
                                .WithMessage("Latitude shoul be between (-90,90) degress.");

            RuleFor(x => x.Longitude).NotNull().WithMessage("Longitude cannot be empty")
                                    .LessThanOrEqualTo(180)
                                    .GreaterThanOrEqualTo(-180)
                                    .WithMessage("Longitude should be between (-180,180) degress.");



        }
        private bool HaveValidPlatformTypeAndCategoryRelationship(PlatformDTO platformDto)
        {
            if(platformDto.PlatformType != null && platformDto.PlatformCategory != null) { 
            var platformTypeValue = (int)platformDto.PlatformType;
            var platformCategoryValue = (int)platformDto.PlatformCategory;

            if (1 <= platformTypeValue && platformTypeValue <= 16)
            {
                if (platformCategoryValue == 1) return true;
                return false;
            }
            else if (17 <= platformTypeValue && platformTypeValue <= 20)
            {
                if (platformCategoryValue == 2) return true;
                return false;
            }
            else if (21 <= platformTypeValue && platformTypeValue <= 28)
            {
                if (platformCategoryValue == 3 || platformCategoryValue == 4) return true;
                return false;
            }
            else if (29 <= platformTypeValue && platformTypeValue <= 31)
            {
                if (platformCategoryValue == 7 || platformCategoryValue == 8 || platformCategoryValue == 9) return true;
                return false;
            }
            else { return false; }
            }
            return true;
        }
    }
}
