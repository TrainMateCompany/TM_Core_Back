using Trainmate.Common.Dto;
using Trainmate.Common.Dto.Request;
using Trainmate.Common.Dto.Response;

namespace Trainmate.Domain.Interfaces.IUser;

public interface ISaveUserService
{
    Task<ResponseDto<UserResponseDto>> Execute(UserRequestDto userRequestDto);
}