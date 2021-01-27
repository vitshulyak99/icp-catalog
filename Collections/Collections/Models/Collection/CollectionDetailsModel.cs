using System.Collections.Generic;
using Collections.Models.Item;

namespace Collections.Models.Collection
{
    public class CollectionDetailsModel : CollectionSimpleModel
    {
        public List<ItemViewModel> Items { get; set; }
    }
}