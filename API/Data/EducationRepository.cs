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
            throw new System.NotImplementedException();
        }

        public async void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Education EditEducation(int userId, int educationId, EducationDTO educationDTO)
        {
            throw new System.NotImplementedException();
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