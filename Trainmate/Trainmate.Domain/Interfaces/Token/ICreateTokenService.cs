
using Trainmate.Repositories.Entities;

namespace Trainmate.Domain.Interfaces.Token
{
    public interface ICreateTokenService 
    {
        string Execute(User user);
    }
}
