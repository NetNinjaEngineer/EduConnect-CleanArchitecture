using EduConnect.Application.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.DTOs.Topic.Validators;
public sealed class UpdateTopicCommandValidator : AbstractValidator<TopicForUpdateDto>
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public UpdateTopicCommandValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;

        RuleFor(x => x.TopicName)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
            .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.MaximumLength50]);

        RuleFor(x => x.TopicNameAr)
          .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
          .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
          .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.MaximumLength50]);
    }
}
