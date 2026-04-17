namespace Clabber.Backend.Domain.Generics
{
    /// <summary>
    /// Marks an entity as the entry point for a cluster of related objects (an Aggregate).
    /// Aggregate Roots are the only objects that should be directly loaded from or saved 
    /// to the database via a Repository.
    /// </summary>
    public class AggregateRoot : BaseEntity
    {
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
