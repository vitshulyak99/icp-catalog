using System.Collections.Generic;
using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
        }

        public Tag(int id , string tagName)
        {
            Id = id;
            Name = tagName;
        }
        public string Name { get; set; }
        public List<Item> ItemTags { get; set; } = new();
    }
}
