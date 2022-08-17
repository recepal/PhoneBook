using MediatR;

namespace PhoneBook.API.Data.Commands
{
    public class DeleteContactDetailCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteContactDetailCommand(Guid id)
        {
            Id = id;
        }
    }
}
