using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Data
{
    public interface IEducationRepository
    {
        Task<Education> AddEducation(int userId, EducationDTO educationDTO);
        Education EditEducation(int userId, int educationId, EducationDTO educationDTO);
        void Delete<T>(T entity) where T: class;
        Task<List<EducationDTO>> GetEducations(int userId);
    }
}