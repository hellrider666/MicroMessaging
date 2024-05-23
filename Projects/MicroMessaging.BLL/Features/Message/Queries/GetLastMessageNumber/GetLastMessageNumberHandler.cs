using AutoMapper;
using MediatR;
using MicroMessaging.BLL.Abstract;
using MicroMessaging.DAL.Repositories.Contracts;

namespace MicroMessaging.BLL.Features.Message.Queries.GetLastMessageNumber
{
    public class GetLastMessageNumberHandler : BaseHandler, IRequestHandler<GetLastMessageNumberRequest, GetLastMessageNumberResponse>
    {
        private readonly IMessageRepository _messageRepository;
        public GetLastMessageNumberHandler(IMapper mapper, IMessageRepository messageRepository) : base(mapper)
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetLastMessageNumberResponse> Handle(GetLastMessageNumberRequest request, CancellationToken cancellationToken)
        {
            var lastMessageNumber = await _messageRepository.GetLastMessageNumberAsync(cancellationToken);

            return new GetLastMessageNumberResponse { LastMessageNumber = lastMessageNumber };
        }
    }
}
