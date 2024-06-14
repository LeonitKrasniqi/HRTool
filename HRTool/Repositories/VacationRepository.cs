using HRTool.Models.Entities;

namespace HRTool.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        public Task<Vacation> CreateVacationAsync(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vacation>> GetAllVacationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Vacation>> GetVacationsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
