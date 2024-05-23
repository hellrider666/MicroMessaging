using AutoMapper;

namespace MicroMessaging.BLL.Abstract
{
    public abstract class BaseHandler
    {
        protected readonly IMapper _mapper;
        public BaseHandler(IMapper mapper) 
        { 
            _mapper = mapper; 
        }
    }
}
