using Trainmate.Common.Dto;
using Trainmate.Domain.Interfaces.Login;
using Trainmate.Repositories.Repositories.Implementation;
using Trainmate.Repositories.Repositories.Interfaces;
using Trainmate.Repositories.Repositories.Implementation; 

// namespace Bios_Back.Domain.Implementation.Login
namespace Trainmate.Domain.Implementation.Login
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {

        private readonly IUserRepository _userRepository;

        public ActiveDirectoryService(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        public bool Execute(LoginDto login)
        {
            var user = _userRepository.ValidateCredentials( login.UserName ,login.Password);

            if (user == null)
                return false;
            return true;
        }
    }
}
