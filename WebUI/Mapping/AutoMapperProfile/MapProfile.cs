using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto.DTOs.AnnouncementDTOs;
using Dto.DTOs.MessageDTOs;
using Dto.DTOs.NewsletterDTOs;
using Entity.Concrete;

namespace WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Announcement, AnnouncementCreateDTO>().ReverseMap();
            CreateMap<Announcement, AnnouncementUpdateDTO>().ReverseMap();
            CreateMap<Announcement, AnnouncementListDTO>().ReverseMap();

            CreateMap<Message, MessageCreateDTO>().ReverseMap();

            CreateMap<Newsletter, NewsletterCreateDTO>().ReverseMap();
        }   
    }
}