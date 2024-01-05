
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trainmate.Common;
using Trainmate.Common.Dto.Request;
using Trainmate.Domain.Interfaces.IUser;

namespace Trainmate.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ISaveUserService _saveUserService;
        // private readonly IGetAllUserPaginatorService _getAllUserPaginatorService;
        // private readonly IUpdateStatusUserService _updateStatusUserService;
        // private readonly IUpdateRoleUserService _updateRoleUserService;
        
        public UserController(ISaveUserService saveUserService
            
            // IGetAllUserPaginatorService getAllUserPaginatorService,
            // IUpdateStatusUserService updateStatusUserService,
            // IUpdateRoleUserService updateRoleUserService)
            )
        {
            _saveUserService = saveUserService;
            // _getAllUserPaginatorService = getAllUserPaginatorService;
            // _updateStatusUserService = updateStatusUserService;
            // _updateRoleUserService= updateRoleUserService;
        }


        [HttpPost()]
        public async Task<IActionResult> SaveUser(UserRequestDto request)
        {
            var result = await _saveUserService.Execute(request);
            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }
            
            Logs.WriteInfoLog($"Return List ProvidersRepresentative successful.");
            return Ok();
        }


        // [HttpGet("GetUsersByRole")]
        // public async Task<IActionResult> GetUsersByRole(int role)
        // {
        //     var result = await _getAllUsersByRoleService.Execute(role);
        //     if (result.HasErrors)
        //     {
        //         return BadRequest(result.Errors);
        //     }
        //
        //     Logs.WriteInfoLog($"Return List ProvidersRepresentative successful.");
        //     return Ok(result);
        // }
        //
        // [HttpPut("UpdateStatusUser")]
        // public async Task<IActionResult> UpdateStatusUser(UserUpdateStatusRequestDto request)
        // {
        //     var result = await _updateStatusUserService.Execute(request);
        //     if (result.HasErrors)
        //     {
        //         return BadRequest(result.Errors);
        //     }
        //     Logs.WriteInfoLog($"Update status User successful.");
        //     return Ok(result);
        // }
        //
        // [HttpPut("UpdateRolUser")]
        // public async Task<IActionResult> UpdateRolUser(UserUpdateRoleRequestDto request)
        // {
        //     var result = await _updateRoleUserService.Execute(request);
        //     if (result.HasErrors)
        //     {
        //         return BadRequest(result.Errors);
        //     }
        //     Logs.WriteInfoLog($"Update Role User successful.");
        //     return Ok(result);
        // }
    }
}
