namespace DaneshkarShop.Domain.Entities.Role;

    public class UserSelectedRole
    {
    #region Properties

    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    #endregion

    //بهتره ریلیشن نزنیم
    #region Relations

    public User.User User { get; set; }
    
    public Role Role { get; set; }

    #endregion
}

