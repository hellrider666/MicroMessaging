using AutoMapper;
using MicroMessaging.BLL.Mapping.DTOs;
using MicroMessaging.DAL.Entities;

namespace MicroMessaging.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageEntity, MessageDTO>();
        }
    }
}
