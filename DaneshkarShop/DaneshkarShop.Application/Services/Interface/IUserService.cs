using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Domain.Entities.User;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IUserService
    {
        #region General Methods

        bool DoesExistUserByMobile(string mobile);

        User FillUserEntity(UserRegisterDTO userDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userDTO);

        User? GetUserByMobile(string mobile);


        #endregion

        #region Admin Side Methods

        List<User> ListOfUsers();
        List<ListOfUsersDTO> ListOfUsersDTO();
        EditUserAdminSideDTO FillEditUserAdminSideDTO(int userId);
        Task<EditUserAdminSideDTO> FillEditUserAdminSideDTOAsync(int userId, CancellationToken cancellation);
        bool EditUserAdminSide(EditUserAdminSideDTO model, List<int> selectedRoles);

        #endregion
    }
}
