namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    bool DoesExistUserByMobile(string mobile);
}

