using DaneshkarShop.Domain.DTOs.AdminSide.LandingPage;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.Entities.User;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class UserService : IUserService
    {

        #region Ctor

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }


        #endregion

        #region General Methods

        public bool DoesExistUserByMobile(string mobile)
        {
            return _userRepository.DoesExistUserByMobile(mobile.Trim());
        }

        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            //Object Mapping
            User user = new()
            {
                Username = userDTO.Mobile,
                Mobile = userDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                CreateDate = DateTime.Now
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

        public bool LoginUser(UserLoginDTO loginDto)
        {
            //Get User By Mobile
            var user = _userRepository.GetUserByMobile(loginDto.Mobile);
            if (user == null)
            {
                return false;
            }

            return true;
        }
        public User? GetUserByMobile(string mobile)
        {
            return _userRepository.GetUserByMobile(mobile);
        }

        #endregion

        #region Admin Side Methods

        public async Task<LandingPageModelDTO?> FillLandingPageModelDTO(CancellationToken cancellationToken)
        {
            LandingPageModelDTO res = new()
            {
                CountOfActiveUsers = await _userRepository.GetCountOfActiveUsers(cancellationToken)
            };

            return res;
        }
        public List<User> ListOfUsers()
        {
            return _userRepository.ListOfUsers();
        }

        //public List<ListOfUsersDTO> ListOfUsersDTO()
        //{
        //    _userRepository.
        //}

        public List<ListOfUsersDTO> ListOfUsersDTO()
        {
            return _userRepository.QueryableUsers()
                                  .OrderByDescending(p => p.CreateDate)
                                  .Select(p => new ListOfUsersDTO()
                                  {
                                      Username = p.Username,
                                      Mobile = p.Mobile,
                                      CreateDate = p.CreateDate,
                                      UserId = p.UserId,
                                      UserAvatar = p.UserAvatar
                                  }).ToList();
        }

        public EditUserAdminSideDTO FillEditUserAdminSideDTO(int userId)
        {
            #region Get User by Id

            var user = _userRepository.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Fill DTO

            EditUserAdminSideDTO model = new()
            {
                Mobile = user.Mobile,
                //SuperAdmin = user.SuperAdmin,
                UserId = userId,
                Username = user.Username,
                UserOriginalAvatar = user.UserAvatar,
                //Get User Roles:
                CurrentUserRolesId = _userRepository.GetListOfUserRolesIdByUserId(userId)

            };

            #endregion

            return model;
        }
        public async Task<EditUserAdminSideDTO> FillEditUserAdminSideDTOAsync(int userId, CancellationToken cancellation)
        {
            #region Get User by Id

            var user = await _userRepository.GetUserByIdAsync(userId, cancellation);
            if (user == null) return null;

            #endregion

            #region Fill DTO

            EditUserAdminSideDTO model = new()
            {
                Mobile = user.Mobile,
                //SuperAdmin = user.SuperAdmin,
                UserId = userId,
                Username = user.Username,
                UserOriginalAvatar = user.UserAvatar,
                //Get User Roles:
                CurrentUserRolesId = await _userRepository.GetListOfUserRolesIdByUserIdAsync(userId, cancellation)

            };

            #endregion

            return model;
        }

        public bool EditUserAdminSide(EditUserAdminSideDTO model, List<int> selectedRoles)
        {
            #region Get User by Id

            var userOrigin = _userRepository.GetUserById(model.UserId);
            if (userOrigin == null) return false;

            #endregion

            #region Update Properties

            userOrigin.Mobile = model.Mobile;
            userOrigin.Username = model.Username;

            if (model.UserAvatar != null)
            {
                //Save New Image
                userOrigin.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", userOrigin.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.UserAvatar.CopyTo(stream);
                }

            }

            #endregion

            #region Update User Roles

            //Delete list of userSelectedRoles:
            List<UserSelectedRole> userSelectedRoles = _userRepository.GetListOfUserSelectedRolesByUserId(model.UserId);
            if (userSelectedRoles.Any())
            {

                _userRepository.DeleteRangeOfUserSelectedRoles(userSelectedRoles);
            }

            if (selectedRoles != null && selectedRoles.Any())
            {
                foreach (var roleId in selectedRoles)
                {
                    UserSelectedRole userSelectedRole = new()
                    {
                        RoleId = roleId,
                        UserId = model.UserId
                    };

                    _roleRepository.AddUserSelectedRoleData(userSelectedRole);
                }
            }

            #endregion

            _userRepository.UpdateUser(userOrigin);
            _userRepository.SaveChange();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            #region Get User by Id

            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user == null || user.IsDelete) return false;

            #endregion

            #region Remove User

            user.IsDelete = true;

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChangeAsync(cancellationToken);

            #endregion

            return true;
        }
        #endregion
    }
}
