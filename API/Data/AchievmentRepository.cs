using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AchievmentRepository : IAchievmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AchievmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Achievment> AddAchievment(int userId, AchievmentToAddAndEditDTO achievmentToAddDTO)
        {
            throw new System.NotImplementedException();
        }

        public async void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Achievment EditAchievment(int userId, int achievmentId, AchievmentToAddAndEditDTO achievmentToEditDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AchievmentDTO>> GetAchievments(int userId)
        {
            var achievments = await _context.Achievment
                .Include(u => u.AchievmentType)
                .Include(u => u.Files)
                .Where(p => p.UserId == userId).ToListAsync();
            var achievmentToReturn = _mapper.Map<List<AchievmentDTO>>(achievments);
            foreach (var element in achievmentToReturn)
            {
                element.Files = await GetFiles(element.Id);
            }
            return achievmentToReturn;
        }

        public async Task<List<AchievmentDTO>> GetAchievmentsOfType(int userId, int typeId)
        {
            var achievments = await _context.Achievment
                .Include(u => u.AchievmentType)
                .Include(u => u.Files)
                .Where(u => u.AchievmentType.Id == typeId && u.UserId == userId).ToListAsync();
            var achievmentToReturn = _mapper.Map<List<AchievmentDTO>>(achievments);
            foreach (var element in achievmentToReturn)
            {
                element.Files = await GetFiles(element.Id);
            }
            return achievmentToReturn;
        }
        public async Task<AchievmentDTO> GetAchievment(int id)
        {
            var achievment = await _context.Achievment
                .Include(u => u.AchievmentType)
                .Include(u => u.Files)
                .FirstOrDefaultAsync(p => p.Id == id);
            var achievmentToReturn = _mapper.Map<AchievmentDTO>(achievment);   
            achievmentToReturn.Files = await GetFiles(achievment.Id);
            return achievmentToReturn;
        }

        public async Task<List<File>> GetFiles(int achId)
        {
            var achievment = await _context.Achievment
                .Include(u => u.AchievmentType)
                .Include(u => u.Files)
                .FirstOrDefaultAsync(p => p.Id == achId);
            List<File> files = new List<File>();
            foreach (var element in achievment.Files)
            {
                var file = new File {
                    Id = element.Id,
                    Name = element.Name,
                    Document = element.Document
                };
                files.Add(file);
            }
            return files;
        }
    }
}