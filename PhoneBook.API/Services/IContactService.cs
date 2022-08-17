using PhoneBook.API.Dtos;
using PhoneBook.API.Requests;

namespace PhoneBook.API.Services
{
    public interface IContactService
    {
        Task<bool> AddContact(AddContactRequest request);
        Task<bool> DeleteContact(Guid id);
        Task<bool> AddContactDetail(AddContactDetailRequest request);
        Task<bool> DeleteContactDetail(Guid id);
        Task<List<ContactDto>> GetContacts();
        Task<ContactWithDetailsDto> GetContactWithDetails(Guid contactId);
        Task<List<ContactDetailDto>> GetContactDetailsForReport();
    }
}
