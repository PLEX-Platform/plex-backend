using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlexBackend.Infrastructure.ContextModels;
using PlexBackend.WebApi.ViewModels;

namespace PlexBackend.WebApi.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentChoice, StudentChoiceViewModel>();
            CreateMap<StudentChoiceViewModel, StudentChoice>();
        }
    }
}
