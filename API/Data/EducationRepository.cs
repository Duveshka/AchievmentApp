using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EducationRepository : IEducationRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EducationRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Education> AddEducation(int userId, EducationDTO educationDTO)
        {
            var education = new Education(educationDTO.EducationName, educationDTO.Degree, 
                educationDTO.Speciality, educationDTO.Graduated, userId);

            await _context.Education.AddAsync(education);
            await _context.SaveChangesAsync();
            return education; 
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Education EditEducation(int educationId, EducationDTO educationDTO)
        {
            var editEducation =  _context.Education.Find(educationId);

            editEducation.EducationName = educationDTO.EducationName;
            editEducation.Degree = educationDTO.Degree;
            editEducation.Speciality = educationDTO.Speciality;
            editEducation.Graduated = educationDTO.Graduated;

            return editEducation; 
        }

        public async Task<List<EducationDTO>> GetEducations(int userId)
        {
            var educations = await _context.Education
                .Where(p => p.UserId == userId).ToListAsync();
            var educationsToReturn = _mapper.Map<List<EducationDTO>>(educations);
            return educationsToReturn;
        }
    }
}