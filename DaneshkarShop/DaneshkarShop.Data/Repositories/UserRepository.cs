﻿using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entities.User;
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

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        SaveChange();
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public User? GetUserByMobile(string mobile)
    {
        return _context.Users.SingleOrDefault(p => p.IsDelete == false && p.Mobile == mobile);
    }
}

