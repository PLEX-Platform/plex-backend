﻿using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexBackend.WebApi.ViewModels
{
    public class StudentChoiceViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PriorityRank { get; set; }
    }
}
