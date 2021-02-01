using System.Collections.Generic;

namespace Collections.Models.Item
{
    public class ItemCreateViewModel
    {
        public string Name { get; set; }
        public List<FieldModel>  Fields { get; set; }
        public List<TagModel> Tags { get; set; }
        public int CollectionId { get; set; }
    }
}
