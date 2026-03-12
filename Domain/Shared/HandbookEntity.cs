using Domain.ValueObjects.Handbook;

namespace Domain.Shared
{
    public abstract class HandbookEntity : BaseEntity
    {
        public Name Name { get; set; } = null!;
        public Description? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
