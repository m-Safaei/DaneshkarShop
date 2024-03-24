using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.Entities.ContactUs;

public class ContactUs
{
    #region Properties

    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; }

    [MaxLength(11)]
    public string Mobile { get; set; }

    public string Message { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;

    public bool IsSeen { get; set; }
    #endregion
}

