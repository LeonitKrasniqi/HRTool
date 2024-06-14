using HRTool.Data;
using HRTool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRTool.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly HRToolDbContext dbContext;

        public VacationRepository(HRToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Vacation> CreateVacationAsync(Vacation vacation)
        {
         dbContext.Vacations.Add(vacation);
         await dbContext.SaveChangesAsync();
            return vacation;
        }

        public Task<List<Vacation>> GetAllVacationsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Vacation> GetVacationByIdAsync(Guid id)
        {
            return await dbContext.Vacations.FirstOrDefaultAsync(x => x.VacationId == id);
        }

        public Task<List<Vacation>> GetVacationsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
