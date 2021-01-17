using System.Collections.Generic;

namespace Collections.DAL.Entities
{
    public class Collection : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<CollectionItem> Items { get; set; }
        public List<CustomField> Fields { get; set; }
    }
}