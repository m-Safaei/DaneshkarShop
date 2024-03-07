using Microsoft.AspNetCore.Http;

namespace DaneshkarShop.Application.DTOs.AdminSide.User;

public record EditUserAdminSideDTO
{
    #region Properties

    public int UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    //public bool SuperAdmin { get; set; }

    public string? UserOriginalAvatar { get; set; }

    public IFormFile? UserAvatar { get; set; }

    public List<int>? CurrentUserRolesId { get; set; }

    #endregion
}

