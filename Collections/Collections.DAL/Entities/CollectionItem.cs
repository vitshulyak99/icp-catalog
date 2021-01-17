using System.Collections.Generic;

namespace Collections.DAL.Entities
{
    public class CollectionItem : BaseEntity
    {
        public string Name { get; set; }
        public List<CollectionItemTag> ItemsTags { get; set; } 
        public List<CustomFieldValue> CustomFieldValues { get; set; }
        public Collection Collection { get; set; }
        public int CollectionId { get; set; }
    }
}