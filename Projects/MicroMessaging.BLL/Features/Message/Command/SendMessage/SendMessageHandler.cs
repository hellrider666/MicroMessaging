using AutoMapper;
using MediatR;
using MicroMessaging.BLL.Abstract;
using MicroMessaging.DAL.Repositories.Contracts;

namespace MicroMessaging.BLL.Features.Message.Command.SendMessage
{
    public class SendMessageHandler : BaseHandler, IRequestHandler<SendMessageRequest, SendMessageResponse>
    {
        private readonly IMessageRepository _messageRepository;
        public SendMessageHandler(IMessageRepository messageRepository, IMapper mapper) : base(mapper)
        {
            _messageRepository = messageRepository;
        }
        public async Task<SendMessageResponse> Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var currentDateTime = DateTime.Now;

            await _messageRepository.SendMessageAsync(request.MessageNumber, request.Message, currentDateTime, cancellationToken);

            return new SendMessageResponse { Message = request.Message, MessageNumber = request.MessageNumber, MessageDateTime = currentDateTime };
        }
    }
}
