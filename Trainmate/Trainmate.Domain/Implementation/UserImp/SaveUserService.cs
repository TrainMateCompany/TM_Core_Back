using AutoMapper;
using Trainmate.Common.Dto;
using Trainmate.Common.Dto.Request;
using Trainmate.Common.Dto.Response;
using Trainmate.Domain.Interfaces.IUser;
using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Repositories.Interfaces;

namespace Trainmate.Domain.Implementation.UserImp;

public class SaveUserService : DomainBase<User>, ISaveUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public SaveUserService(IUserRepository userRepository, IMapper iMapper) : base(userRepository)
    {
        _userRepository = userRepository;
        _mapper = iMapper;
    }
    public async Task<ResponseDto<UserResponseDto>> Execute(UserRequestDto userRequestDto)
    {
        var response = new ResponseDto<UserResponseDto>();
        var user = await _userRepository.Save(_mapper.Map<User>(userRequestDto));
        response.Result = _mapper.Map<UserResponseDto>(user);
        
        return response;
    }
}