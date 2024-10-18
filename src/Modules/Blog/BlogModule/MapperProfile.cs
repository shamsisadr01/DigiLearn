﻿using AutoMapper;
using BlogModule.Domain;
using BlogModule.Service.DTOs.Command;
using BlogModule.Service.DTOs.Query;

namespace BlogModule;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, BlogCategoryDto>().ReverseMap();
        CreateMap<Category, CreateBlogCategoryCommand>().ReverseMap();


        CreateMap<Post, CreatePostCommand>().ReverseMap();
        CreateMap<Post, BlogPostDto>().ReverseMap();
    }
}