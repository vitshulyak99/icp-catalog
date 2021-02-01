using System.Collections.Generic;
using Collections.DAL.Entities.Identity;

namespace Collections.DAL.Entities
{
    public class Collection : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Theme Theme { get; set; }
        public AppUser Owner { get; set; }
        public List<Item> Items { get; set; } = new();
        public List<Field> Fields { get; set; } = new();
    }
}
