using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class FieldValue : Field
    {
        public int FieldId { get; set; }
        public string Value { get; set; }
        public Item Item { get; set; }
    }
}
