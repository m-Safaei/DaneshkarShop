using DaneshkarShop.Application.DTOs.AdminSide.LandingPage;
using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.Entities.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    #region Ctor


    private readonly DaneshkarDbContext _context;

    public UserRepository(DaneshkarDbContext context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    public bool DoesExistUserByMobile(string mobile)
    {
        return _context.Users.Any(e => e.Mobile == mobile);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        SaveChange();
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public User? GetUserByMobile(string mobile)
    {
        return _context.Users.SingleOrDefault(p => p.IsDelete == false && p.Mobile == mobile);
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public async Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellation)
    {
        return await _context.Users.FindAsync(userId);
    }
    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }
    #endregion

    #region Admin Side methods

    public async Task<int> GetCountOfActiveUsers(CancellationToken cancellation)
    {
        return await _context.Users.AsNoTracking()
                                    .Where(p => !p.IsDelete)
                                    .CountAsync(cancellation);

    }
    public List<User> ListOfUsers()
    {

        return _context.Users
                        .Where(p => !p.IsDelete)
                        .OrderByDescending(p => p.CreateDate)
                        .ToList();
    }

    public IQueryable<User> QueryableUsers()
    {

        return _context.Users
            .Where(p => !p.IsDelete);
    }

    //public List<ListOfUsersDTO> ListOfUsersWithDTO()
    //{
    //    var users = _context.Users
    //                                   .Where(p => !p.IsDelete)
    //                                   .OrderByDescending(p => p.CreateDate)
    //                                   .Select(p => new ListOfUsersDTO()
    //                                   {
    //                                       Username = p.Username,
    //                                       Mobile = p.Mobile,
    //                                       CreateDate = p.CreateDate
    //                                   })
    //                                   .ToList();
    //    return users;

    //}
    public List<int> GetListOfUserRolesIdByUserId(int userId)
    {
        return _context.UserSelectedRoles
                        .Where(p => p.UserId == userId)
                        .Select(p => p.RoleId)
                        .ToList();
    }

    public async Task<List<int>> GetListOfUserRolesIdByUserIdAsync(int userId,CancellationToken cancellation)
    {
        return await _context.UserSelectedRoles
                        .Where(p => p.UserId == userId)
                        .Select(p => p.RoleId)
                        .ToListAsync();
    }

    public List<UserSelectedRole> GetListOfUserSelectedRolesByUserId(int userId)
    {
        return _context.UserSelectedRoles.Where(p => p.UserId == userId).ToList();
    }

    public void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles)
    {
        _context.UserSelectedRoles.RemoveRange(userSelectedRoles);
    }
    #endregion
}

