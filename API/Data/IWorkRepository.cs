using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Data
{
    public interface IWorkRepository
    {
        Task<Work> AddWork(int userId, WorkDTO workDTO);
        Work EditWork(int workId, WorkDTO workDTO);
        void Delete<T>(T entity) where T: class;
        Task<List<WorkDTO>> GetWorks(int userId);
        Task<bool> SaveAll();
        Task<WorkDTO> GetWork(int id);
    }
}