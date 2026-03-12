namespace Domain.Shared
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is BaseEntity other)
                return Id.Equals(other.Id);

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
