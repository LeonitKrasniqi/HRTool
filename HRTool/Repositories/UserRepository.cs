using HRTool.Data;
using HRTool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRTool.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HRToolDbContext dbContext;
        public UserRepository(HRToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public  async Task<User> CreateUserAsync(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;    
            
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return user;
           
        }
    }
}
