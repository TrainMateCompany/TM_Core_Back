using Trainmate.Common.Dto;
using Trainmate.Domain.Interfaces.Login;

namespace Bios_Back.Domain.Implementation.Login
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {

        private List<LoginDto> users;

        public ActiveDirectoryService()
        {

            users = new List<LoginDto>()
            {
                new LoginDto { UserName = "test", Password = "123456" },
                new LoginDto { UserName = "test2", Password = "000000" },
                new LoginDto { UserName = "super_admin", Password = "000000" }
            };

        }

        public bool Execute(LoginDto login)
        {
            var user = users.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);

            if (user == null)
                return false;
            return true;
        }
    }
}
