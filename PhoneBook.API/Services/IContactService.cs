using PhoneBook.API.Requests;

namespace PhoneBook.API.Services
{
    public interface IContactService
    {
        Task<bool> AddContact(AddContactRequest request);
    }
}
