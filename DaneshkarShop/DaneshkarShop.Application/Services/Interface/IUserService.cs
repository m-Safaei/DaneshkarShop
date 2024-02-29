using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Domain.Entities.User;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IUserService
    {
        bool DoesExistUserByMobile(string mobile);

        User FillUserEntity(UserRegisterDTO userDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userDTO);
    }
}
