using System.Collections.Generic;

namespace Collections.Models.Item
{
    public class ItemCreateModel
    {
        public string Name { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<FieldValueModel> Fields { get; set; }
    } 

    public class ItemViewModel : ItemCreateModel
    {
        public int Id { get; set; }
    }
}
