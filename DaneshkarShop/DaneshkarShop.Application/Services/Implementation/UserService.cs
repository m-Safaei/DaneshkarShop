using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Domain.Entities.User;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class UserService : IUserService
    {

        #region Ctor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        #endregion
        public bool DoesExistUserByMobile(string mobile)
        {
            return _userRepository.DoesExistUserByMobile(mobile.Trim());
        }

        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            //Object Mapping
            User user = new()
            {
                Username = userDTO.UserName,
                Mobile = userDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password)
            };
            return user;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool RegisterUser(UserRegisterDTO userDTO)
        {
            //Does Exist any user by mobile
            var doesExist = DoesExistUserByMobile(userDTO.Mobile);
            if (doesExist)
            {
                return false;
            }

            //Fill Entity
            var user = FillUserEntity(userDTO);

            //Add User to Database
            AddUser(user);

            return true;
        }
    }
}
