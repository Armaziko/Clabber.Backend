namespace SoundPromoMarketplace.Domain.Generics
{
    public class BaseEntity
    {
        public string Id { get; set; }

        public BaseEntity(string id)
        {
            this.Id = id;
        }
    }
}
