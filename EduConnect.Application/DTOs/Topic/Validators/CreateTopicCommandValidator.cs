using EduConnect.Application.Helpers;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace EduConnect.Application.DTOs.Topic.Validators
{
    public class CreateTopicCommandValidator : AbstractValidator<TopicForCreationDto>
    {
        private readonly IStringLocalizer<CreateTopicCommandValidator> _localizer;

        public CreateTopicCommandValidator(IStringLocalizer<CreateTopicCommandValidator> localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.TopicName)
                .NotEmpty().WithMessage(string.Format(_localizer[SharedResourcesKeys.NotEmpty], "TopicName"))
                .NotNull().WithMessage(string.Format(_localizer[SharedResourcesKeys.NotNull], "TopicName"))
                .MaximumLength(50).WithMessage(string.Format(_localizer[SharedResourcesKeys.MaximumLength50], "TopicName"));


            RuleFor(x => x.TopicNameAr)
                .NotEmpty().WithMessage(string.Format(_localizer[SharedResourcesKeys.NotEmpty], "TopicNameAr"))
                .NotNull().WithMessage(string.Format(_localizer[SharedResourcesKeys.NotNull], "TopicNameAr"))
                .MaximumLength(50).WithMessage(string.Format(_localizer[SharedResourcesKeys.MaximumLength50], "TopicNameAr"));
        }
    }
}
