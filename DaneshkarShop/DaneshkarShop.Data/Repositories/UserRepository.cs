using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.IRepositories;

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

    public bool DoesExistUserByMobile(string mobile)
    {
        return _context.Users.Any(e => e.Mobile == mobile);
    }
}

