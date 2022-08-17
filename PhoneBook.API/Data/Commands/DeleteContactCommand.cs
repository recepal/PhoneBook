using MediatR;

namespace PhoneBook.API.Data.Commands
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteContactCommand(Guid id)
        {
            Id = id;
        }
    }
}
