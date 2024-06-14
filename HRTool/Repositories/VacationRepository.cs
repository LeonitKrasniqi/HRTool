using HRTool.Data;
using HRTool.Models.Entities;

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

        public Task<Vacation> GetVacationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vacation>> GetVacationsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
