using FluentValidation;

namespace EduConnect.Application.DTOs.Topic.Validators;
public sealed class UpdateTopicCommandValidator : AbstractValidator<TopicForUpdateDto>
{
    public UpdateTopicCommandValidator()
    {
        RuleFor(x => x.TopicName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must be no more than 50 characters long.");

    }
}
