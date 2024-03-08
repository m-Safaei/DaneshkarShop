using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.Entities.Role;

public class Role
{
    #region Properties

    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string RoleTitle { get; set; }

    [MaxLength(100)]
    [Required]
    public string RoleUniqueName { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsDelete { get; set; }

    #endregion

    #region Relations

    public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion
}

