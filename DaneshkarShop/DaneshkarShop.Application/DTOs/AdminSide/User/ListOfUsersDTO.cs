namespace DaneshkarShop.Application.DTOs.AdminSide.User;

public class ListOfUsersDTO
{
    #region Properties

    public int UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }


    public DateTime CreateDate { get; set; }

    public string? UserAvatar { get; set; }



    #endregion
}

