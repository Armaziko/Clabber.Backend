namespace Clabber.Backend.Domain.Generics
{
    /// <summary>
    /// Provides a base contract for all domain objects that require a unique identity.
    /// This ensures every entity in the system can be identified and compared by a Guid.
    /// </summary>
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public BaseEntity(Guid id)
        {
            this.Id = id;
        }
    }
}
