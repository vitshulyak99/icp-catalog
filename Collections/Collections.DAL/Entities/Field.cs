using Collections.DAL.Entities.Enums;
using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }
        public Collection Collection { get; set; }
    }
}
