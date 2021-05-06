using System.Collections.Generic;
using System.Linq;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Achievment, AchievmentDTO>()
                .ConstructUsing(achievment => new AchievmentDTO
                {
                    Id = achievment.Id,
                    Name = achievment.Name,
                    AchievmentType = new AchievmentType
                    {
                        Id = achievment.AchievmentType.Id,
                        Name = achievment.AchievmentType.Name,
                        Description = achievment.AchievmentType.Description
                    },
                    Description = achievment.Description,
                });

            CreateMap<Work, WorkDTO>()
                .ConstructUsing(work => new WorkDTO
                    {
                        Id = work.Id,
                        Company = work.Company,
                        Speciality = work.Speciality,
                        StartDate = work.StartDate,
                        FinishDate = work.FinishDate,
                        Description = work.Description
                    });
                
            CreateMap<Education, EducationDTO>()
                .ConstructUsing(education => new EducationDTO
                    {
                        Id = education.Id,
                        EducationName = education.EducationName,
                        Degree = education.Degree,
                        Speciality = education.Speciality,
                        Graduated = education.Graduated
                    });
        }
    }
}