using DaneshkarShop.Application.Services.Interface;
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
    }
}
