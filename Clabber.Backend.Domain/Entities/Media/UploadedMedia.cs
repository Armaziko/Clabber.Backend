using Clabber.Backend.Domain.Entities.Profile;
using Clabber.Backend.Domain.Enums;
using Clabber.Backend.Domain.Generics;

namespace Clabber.Backend.Domain.Entities.Media
{
    public class UploadedMedia : AggregateRoot
    {
        public UploadedMedia(Guid id) : base(id)
        {
        }

        public Guid AccountId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string S3Url { get; set; } = string.Empty;
        
        public MediaType MediaType { get; set; }

        public decimal SizeMB { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
