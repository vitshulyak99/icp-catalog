namespace Collections.DAL.Entities
{
    public class FieldValue : BaseEntity
    {
        public Field Field { get; set; }
        public string Value { get; set; }
        public Item Item { get; set; }
    }
}
