using System.Collections.Generic;
using Collections.DAL.Entities.Enums;

namespace Collections.DAL.Entities
{
    public class CustomField : BaseEntity
    {
        public string Name { get; set; }
        public CustomFieldType Type { get; set; }
        public List<CustomFieldValue> Values { get; set; }
        public Collection Collection { get; set; }
        public int CollectionId { get; set; }
    }
}