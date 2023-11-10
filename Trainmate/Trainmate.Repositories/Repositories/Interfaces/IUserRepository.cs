using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Infrastructure;

namespace Trainmate.Repositories.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByUserName(string userName);

        //Task<Tuple<int, IQueryable<UserDto>>> GetAllUserQuery(GetAllUserRequestDto request);

        //Task<bool> UpdateActiveUser(UserUpdateStatusRequestDto request);

        //Task<bool> UpdateRoleUser(UserUpdateRoleRequestDto request);
    }
}
