using MediatR;
using PhoneBook.API.Dtos;

namespace PhoneBook.API.Data.Queries
{
    public class GetContactsQuery : IRequest<List<ContactDto>>
    {
    }
}
