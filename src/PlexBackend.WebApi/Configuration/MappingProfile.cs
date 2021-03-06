using AutoMapper;
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
            CreateMap<CreatePlaylistViewModel, Playlist>();
            CreateMap<Playlist, CreatePlaylistViewModel>();
            CreateMap<ProjectSubmitViewModel, Project>();
            CreateMap<Project, ProjectSubmitViewModel>();
            CreateMap<Project, ExistingProjectViewModel>();
            CreateMap<ExistingProjectViewModel, Project>();
        }
    }
}