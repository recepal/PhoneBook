using MediatR;
using PhoneBook.API.Dtos;

namespace PhoneBook.API.Data.Queries
{
    public class GetContactWithDetailsQuery : IRequest<ContactWithDetailsDto>
    {
        public Guid ContactId { get; set; }
        public GetContactWithDetailsQuery(Guid contactId)
        {
            ContactId = contactId;
        }
    }
}
