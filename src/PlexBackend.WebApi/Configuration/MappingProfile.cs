using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using PlexBackend.WebApi.ViewModels;

namespace PlexBackend.WebApi.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentChoice, StudentChoiceViewModel>();
            CreateMap<StudentChoiceViewModel, StudentChoice>();

            CreateMap<ProjectPriority, StudentChoice>();
            CreateMap<StudentChoice, ProjectPriority>();

            CreateMap<Playlist, RetrievePlaylistViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<CreatePlaylistViewModel, Playlist>();
            CreateMap<Playlist, CreatePlaylistViewModel>();
            CreateMap<ProjectViewModel, Project>();
        }
    }
}