using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Media
{
    public class MediaCollectionItem : BaseEntity
    {
        public MediaCollectionItem(Guid id) : base(id)
        {
        }

        public Guid MediaCollectionId { get; set; }
        public Guid UploadedMediaId { get; set; }
    }
}
