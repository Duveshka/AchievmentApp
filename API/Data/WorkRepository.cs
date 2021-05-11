using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class WorkRepository : IWorkRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public WorkRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Work> AddWork(int userId, WorkDTO workDTO)
        {
            var work = new Work(workDTO.Company, workDTO.Speciality, 
                workDTO.StartDate, workDTO.FinishDate, workDTO.Description, userId);

            await _context.Work.AddAsync(work);
            await _context.SaveChangesAsync();
            return work; 
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Work EditWork(int workId, WorkDTO workDTO)
        {
            var editWork =  _context.Work.Find(workId);

            editWork.Company = workDTO.Company;
            editWork.Speciality = workDTO.Speciality;
            editWork.StartDate = workDTO.StartDate;
            editWork.FinishDate = workDTO.FinishDate;
            editWork.Description = workDTO.Description;
            

            return editWork; 
        }

        public async Task<List<WorkDTO>> GetWorks(int userId)
        {
            var works = await _context.Work
                .Where(p => p.UserId == userId).ToListAsync();
            var worksToReturn = _mapper.Map<List<WorkDTO>>(works);
            return worksToReturn;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<WorkDTO> GetWork(int id)
        {
            var work = await _context.Work
                .FirstOrDefaultAsync(p => p.Id == id);
            var workToReturn = _mapper.Map<WorkDTO>(work);   
            return workToReturn;
        }
    }
}