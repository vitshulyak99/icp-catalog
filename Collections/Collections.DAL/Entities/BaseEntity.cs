namespace Collections.DAL.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public abstract TKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<int>
    {
        public override int Id { get; set; }
    }
}