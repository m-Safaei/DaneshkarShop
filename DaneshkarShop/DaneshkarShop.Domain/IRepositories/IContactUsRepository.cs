using DaneshkarShop.Domain.Entities.ContactUs;

namespace DaneshkarShop.Domain.IRepositories;

public interface IContactUsRepository
{
    Task SaveChangeAsync();
    Task AddContactUsToDatabase(ContactUs contactUs);
}

