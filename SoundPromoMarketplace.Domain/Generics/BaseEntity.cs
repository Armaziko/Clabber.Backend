namespace SoundPromoMarketplace.Domain.Generics
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity(Guid id)
        {
            this.Id = id;
        }
    }
}
