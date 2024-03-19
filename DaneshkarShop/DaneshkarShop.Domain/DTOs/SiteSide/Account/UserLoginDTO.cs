namespace DaneshkarShop.Domain.DTOs.SiteSide.Account
{
    public class UserLoginDTO
    {
        #region properties

        public string Mobile { get; set; }

        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
        #endregion
    }
}
