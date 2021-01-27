using System.Collections.Generic;
using Collections.DAL.Entities.Identity;
using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public List<FieldValue> Fields { get; set; } = new();
        public List<AppUser> Likes { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public Collection Collection { get; set; }
    }
}
