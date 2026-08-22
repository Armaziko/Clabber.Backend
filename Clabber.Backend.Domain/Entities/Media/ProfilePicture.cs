using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Media
{
    public class ProfilePicture : BaseEntity
    {
        public ProfilePicture(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public Guid UploadedMediaId { get; set;  } 

        public UploadedMedia UploadedMedia { get; set; } = default!;
    }
}
