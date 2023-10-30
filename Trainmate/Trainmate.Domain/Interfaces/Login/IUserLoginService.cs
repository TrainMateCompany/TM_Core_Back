using Trainmate.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainmate.Domain.Interfaces.Login
{
    public interface IUserLoginService
    {

        Task<ResponseDto<string>> Execute(LoginDto login);

    }
}
