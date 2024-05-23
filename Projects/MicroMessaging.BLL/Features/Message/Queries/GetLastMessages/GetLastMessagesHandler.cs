using AutoMapper;
using MediatR;
using MicroMessaging.BLL.Abstract;
using MicroMessaging.BLL.Mapping.DTOs;
using MicroMessaging.DAL.Entities;
using MicroMessaging.DAL.Repositories.Contracts;

namespace MicroMessaging.BLL.Features.Message.Queries.GetLastMessages
{
    public class GetLastMessagesHandler : BaseHandler, IRequestHandler<GetLastMessagesRequest, GetLastMessagesResponse>
    {
        private readonly IMessageRepository _messageRepository;
        public GetLastMessagesHandler(IMessageRepository messageRepository, IMapper mapper) : base(mapper)
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetLastMessagesResponse> Handle(GetLastMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetLastMessagesAsync(request.StartDate, request.EndDate, cancellationToken);

            return new GetLastMessagesResponse { Messages = _mapper.Map<List<MessageEntity>, List<MessageDTO>>(messages)};
        }
    }
}
