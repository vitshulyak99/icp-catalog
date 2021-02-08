using System.Collections.Generic;
using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public List<FieldValue> Fields { get; set; } = new();
        public List<Like> Likes { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public Collection Collection { get; set; }
        
        public NpgsqlTsVector SearchVector { get; set; }
    }
}
