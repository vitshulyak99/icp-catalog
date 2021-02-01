using System.Collections.Generic;

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

        public sealed override int Id
        {
            get => base.Id;
            set => base.Id = value;
        }

        public string Name { get; set; }
        public List<Item> ItemTags { get; set; } = new();
    }
}
