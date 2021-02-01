using System.Collections.Generic;
using Collections.Models.Collection;

namespace Collections.Models.Item
{
    public class ItemCreateModel 
    {
        public string Name { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<FieldValueModel> Fields { get; set; }
        public int CollectionId { get; set; }
    } 

    public class ItemViewModel : ItemCreateModel
    {
        public int Id { get; set; }
        public List<int> Likes { get; set; } = new();
        public new List<FieldValueViewModel> Fields { get; set; }
    }

    public class ItemSearchResultViewModel : ItemViewModel {
        public CollectionSimpleModel Collection { get; set; }
    }
}
