using HRTool.Models.Entities;

namespace HRTool.Repositories
{
    public interface IVacationRepository
    {
        Task<Vacation> CreateVacationAsync(Vacation vacation);  
        Task<List<Vacation>> GetVacationsByUserIdAsync(Guid userId);
        Task<List<Vacation>> GetAllVacationsAsync();

    }
}
