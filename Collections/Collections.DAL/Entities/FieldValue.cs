using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class FieldValue : BaseEntity
    {
        public Field Field { get; set; }
        public string Value { get; set; }
        public Item Item { get; set; }
        public NpgsqlTsVector SearchVector { get; set; }
    }
}
