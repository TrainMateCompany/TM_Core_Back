using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Infrastructure;

namespace Trainmate.Repositories.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByUserName(string userName);
        User ValidateCredentials(string userName, string password);
    }
}
