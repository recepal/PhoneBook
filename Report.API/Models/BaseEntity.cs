namespace Report.API.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
