using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Common.Dto.Request;
using Trainmate.Repositories.Entities;

namespace Trainmate.Domain.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserRequestDto>().ReverseMap();
        }
    }
}
