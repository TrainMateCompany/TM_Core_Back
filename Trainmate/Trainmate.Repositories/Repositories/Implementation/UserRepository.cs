using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trainmate.Repositories.Context;
using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Infrastructure;
using Trainmate.Repositories.Repositories.Interfaces;

namespace Trainmate.Repositories.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository

    {
    // private IUserRepository _userRepositoryImplementation;

    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public User GetUserByUserName(string userName)
    {
        var user = Context.Users.FirstOrDefault(e => e.UserName == userName);
        if (user != null)
        {
            return null;
        }

        return user;
    }



    public User ValidateCredentials(string userName, string password)
    {
        var user = Context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        return user;

    }

    //async Task<Tuple<int, IQueryable<UserDto>>> IUserRepository.GetAllUserQuery(GetAllUserRequestDto request)
    //{
    //    var query = Context.Users.Where(x => x.Id > 0);

    //    if (!string.IsNullOrEmpty(request.Filter))
    //    {
    //        query = query.Where(x => x.Name.Contains(request.Filter)
    //                                 || x.Email.Contains(request.Filter)
    //                                 );
    //    }
    //    if (request.Active != null)
    //    {

    //        query = query.Where(x => x.Active.Equals(request.Active));
    //    }
    //    if (request.RoleId != null)
    //    {
    //        query = query.Where(x => x.RoleId.Equals(request.RoleId));
    //    }
    //    var querySelect = query.Select(x => new UserDto()
    //    {
    //        Id = x.Id,
    //        CreationDate = x.CreationDate,
    //        Name = x.Name,
    //        RoleId = x.RoleId,
    //        Active = x.Active,
    //        Role = x.RoleId.HasValue ? x.Role.Description : string.Empty,
    //        UserName = x.UserName,
    //        Email = x.Email
    //    });

    //    var count = await querySelect.CountAsync();
    //    if (request.Pagination.PageNumber != 0 && request.Pagination.PageSize != 0)
    //        querySelect = querySelect.Skip(request.Pagination.PageSize * (request.Pagination.PageNumber - 1))
    //            .Take(request.Pagination.PageSize);

    //    return Tuple.Create(count, querySelect);


    //}

    //async Task<bool> IUserRepository.UpdateActiveUser(UserUpdateStatusRequestDto request)
    //{
    //    if (request.ListUser.Any())
    //    {
    //        foreach (var item in request.ListUser)
    //        {
    //            var query = Context.Users.Where(x => x.Id == item.UserId)
    //                    .ExecuteUpdate(setters => setters.SetProperty(b => b.Active, item.Active));
    //        }
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //async Task<bool> IUserRepository.UpdateRoleUser(UserUpdateRoleRequestDto request)
    //{
    //    try
    //    {
    //        var query = Context.Users.Where(x => x.Id == request.UserId)
    //         .ExecuteUpdate(setters => setters.SetProperty(b => b.RoleId, request.RoleId));
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }

    //}
    }
}
