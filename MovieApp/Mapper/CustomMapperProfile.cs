using AutoMapper;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;
using MovieApp.DTOs;
using MovieApp.DTOs.ArticleDto;
using MovieApp.DTOs.CommentDto;

namespace MovieApp.Mapper
{
    public class CustomMapperProfile : Profile
    {
        public CustomMapperProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, ArticleCreateDto>().ReverseMap();
            CreateMap<Reader, ReaderDto>().ReverseMap();
            CreateMap<Reader, ReaderCreateDto>().ReverseMap();
            CreateMap<Writer, WriterDto>().ReverseMap();
            CreateMap<Writer, WriterCreateDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentCreateDto>().ReverseMap();
        }

        
    }
}
