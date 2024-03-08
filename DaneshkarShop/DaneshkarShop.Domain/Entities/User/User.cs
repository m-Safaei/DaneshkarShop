using System.Collections.ObjectModel;
using DaneshkarShop.Domain.Entities.Role;

namespace DaneshkarShop.Domain.Entities.User;

public class User
{
    #region Properties

    public int UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string Password { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsDelete { get; set; }

    public bool SuperAdmin { get; set; }

    public string? UserAvatar { get; set; }

    #endregion


    //Relations:
    #region Navigation Properties(relations) 

    public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion
}

