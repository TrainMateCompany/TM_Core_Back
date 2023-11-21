using FluentValidation;
using Trainmate.Common.Dto;
using Trainmate.Domain.Interfaces.Login;
using Trainmate.Domain.Interfaces.Token;
using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Repositories.Interfaces;

namespace Trainmate.Domain.Implementation.Login
{
    public class UserLoginService : DomainBase<User>, IUserLoginService
    {
        private readonly IValidator<LoginDto> _loginValidator;
        private readonly ICreateTokenService _createTokenService;
        private readonly IUserRepository _repository;
        public UserLoginService(IUserRepository repository, IValidator<LoginDto> loginValidator, ICreateTokenService createTokenService, IActiveDirectoryService activeDirectoryService) : base(repository)
        {
            _loginValidator = loginValidator;
            _createTokenService = createTokenService;
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

           var user = await Repository.FirstOfDefaultAsync(u => u.UserName == login.UserName);
            if (user == null) 
            {
                result.Errors.Add("Usuario Invalido");
                return result;
            }
            result.Result = _createTokenService.Execute(user);
            return result;
        }
        

    }
}
