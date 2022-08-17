using MediatR;
using PhoneBook.API.Dtos;

namespace PhoneBook.API.Data.Queries
{
    public class GetContactDetailsForReportQuery : IRequest<List<ContactDetailDto>>
    {
        
    }
}
