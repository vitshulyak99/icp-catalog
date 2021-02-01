using System.Collections.Generic;
using Collections.DAL.Entities.Enums;

namespace Collections.DAL.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }
        public Collection Collection { get; set; }
        public List<FieldValue> Values { get; set; }
    }
}
