using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Media
{
    public class MediaCollection : AggregateRoot
    {
        public MediaCollection(Guid id) : base(id)
        {
        }

        public Guid OwnerId { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation properties

        public ICollection<MediaCollectionItem> MediaCollectionItems { get; set; } = new List<MediaCollectionItem>();
    }
}
