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
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Work EditWork(int userId, int workId, WorkDTO workDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<WorkDTO>> GetWorks(int userId)
        {
            var works = await _context.Work
                .Where(p => p.UserId == userId).ToListAsync();
            var worksToReturn = _mapper.Map<List<WorkDTO>>(works);
            return worksToReturn;
        }
    }
}