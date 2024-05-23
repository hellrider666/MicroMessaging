using FluentValidation;

namespace MicroMessaging.BLL.Features.Message.Queries.GetLastMessages
{
    public class GetLastMessagesValidator : AbstractValidator<GetLastMessagesRequest>
    {
        public GetLastMessagesValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.StartDate)
                .NotEmpty()
                    .WithMessage("Start DateTime cannot be empty");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                    .WithMessage("End DateTime cannot be empty");

            RuleFor(x => new { x.StartDate, x.EndDate })
                .Must(x =>
                {
                    return DateTime.Compare(x.StartDate, x.EndDate) < 0;

                }).WithMessage("The starting date and time and cannot be greater than the ending date or equal to it");
        }
    }
}
