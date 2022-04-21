using AutoMapper;
using NewsApp.DataAccessor.Entities;
using NewsApp.Contracts.Dtos;
using System;

namespace NewsApp.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest=>dest.Id,o=>o.MapFrom(src=>src.Id))
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName));
            CreateMap<CommentsDto, Comments>();
            CreateMap<NewsDto, News>();
            CreateMap<TypeDto, DataAccessor.Entities.Type>();
            CreateMap<PicturesDto, Pictures>();



        }

        private void FromDataAccessorLayer()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName));
            CreateMap<Comments, CommentsDto>();
            CreateMap<News, NewsDto>();
            CreateMap<DataAccessor.Entities.Type, TypeDto>();
            CreateMap<Pictures, PicturesDto>();

        }
    }
}
