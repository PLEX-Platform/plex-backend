﻿using PlexBackend.Core.Entities;
using PlexBackend.Core.Helpers;
using PlexBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public ValidateProjectExists CheckIfProjectExists(int DexId)
        {
            Project project = projectRepository.FindByCondition(proj => proj.DEXId == DexId).FirstOrDefault();
            if (projectRepository.FindByCondition(proj => proj.DEXId == DexId) == null)
            {
                return new ValidateProjectExists
                {
                    Exists = false,
                    Project = null
                };
            }

            return new ValidateProjectExists
            {
                Exists = true,
                Project = project
            };
        }

        public void AddNewProject(Project project)
        {
            projectRepository.Create(project);
        }
    }
}