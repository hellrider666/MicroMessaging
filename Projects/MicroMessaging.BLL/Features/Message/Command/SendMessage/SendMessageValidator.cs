using FluentValidation;
using MicroMessaging.DAL.Repositories.Contracts;

namespace MicroMessaging.BLL.Features.Message.Command.SendMessage
{
    public class SendMessageValidator : AbstractValidator<SendMessageRequest>
    {
        private readonly IMessageRepository _messageRepository;
        public SendMessageValidator(IMessageRepository messageRepository) 
        {
            _messageRepository = messageRepository; 

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Message)
                .NotNull()
                    .WithMessage("Message cannot be empty")
                .NotEmpty()
                    .WithMessage("Message cannot be empty")
                .MaximumLength(128)
                    .WithMessage("Message length cannot be more than 128 characters");

            RuleFor(x => x.MessageNumber)
                .NotEmpty()
                    .WithMessage("Message number cannot be empty")
                .NotNull()
                    .WithMessage("Message number cannot be empty")
                .MustAsync(async (number, cancellation) =>
                {
                    var exist = await _messageRepository.GetMessageByNumberAsync(number, cancellation);

                    return exist == null;
                }).WithMessage("Message number already exists");
        }
    }
}
