using Trainmate.Domain.Interfaces.Login;
using Trainmate.Domain.Interfaces.Token;
using Trainmate.Repositories.Entities;

namespace Trainmate.Domain.Implementation.Login
{
    public class UserLoginService : DomainBase<User>, IUserLoginService
    {
        private readonly IValidator<LoginDto> _loginValidator;
        private readonly ICreateTokenService _createTokenService;
        private readonly IActiveDirectoryService _activeDirectoryService;
        public UserLoginService(IUserRepository repository, IValidator<LoginDto> loginValidator, ICreateTokenService createTokenService, IActiveDirectoryService activeDirectoryService) : base(repository)
        {
            _loginValidator = loginValidator;
            _createTokenService = createTokenService;
            _activeDirectoryService = activeDirectoryService;
        }

        public async Task<ResponseDto<string>> Execute(LoginDto login)
        {
            var result = new ResponseDto<string>();
            var validationResult = await _loginValidator.ValidateAsync(login);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    result.Errors.Add(error.ErrorMessage);

                return result;
            }
            // Aqui implementamos la conexin a LDAP

            if (!_activeDirectoryService.Execute(login))
            {
                result.Errors.Add("El usuario no se encuentra registrado");
                return result;
            }

            var user = await Repository.FirstOfDefaultAsync(x => x.UserName == login.UserName, x => x.Role);
            if (user == null)
            {
                result.Errors.Add("Usuario Invalido");
                return result;
            }
            if (user.Active == false)
            {
                result.Errors.Add("Usuario Inactivo");
                return result;
            }

            result.Result = _createTokenService.Execute(user);

            return result;
        }


    }
}
