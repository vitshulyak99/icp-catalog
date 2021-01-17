using System.Collections.Generic;

namespace Collections.DAL.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<CollectionItemTag> ItemTags { get; set; }
    }
}