using EduConnect.Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.DTOs.Topic.Validators
{
    public class CreateTopicCommandValidator : AbstractValidator<TopicForCreationDto>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public CreateTopicCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.TopicName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.MaximumLength50]);
        }
    }
}
