using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Data
{
    public interface IAchievmentRepository
    {
        Task<Achievment> AddAchievment(int userId, AchievmentToAddAndEditDTO  achievmentToAddDTO);
        Achievment EditAchievment(int userId, int achievmentId, AchievmentToAddAndEditDTO achievmentToEditDTO);
        void Delete<T>(T entity) where T: class;
        Task<List<AchievmentDTO>> GetAchievments(int userId);
        Task<List<AchievmentDTO>> GetAchievmentsOfType(int userId, int typeId);
        Task<AchievmentDTO> GetAchievment(int id);
        Task<List<File>> GetFiles(int id);
    }
}