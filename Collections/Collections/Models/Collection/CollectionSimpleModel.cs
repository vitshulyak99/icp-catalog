using System.Collections.Generic;
using Collections.Models.Item;

namespace Collections.Models.Collection
{
    public class CollectionSimpleModel : CollectionModel
    {
        public int Id { get; set; }
        public int ItemsCount { get; set; }
        public SimpleUserInfoModel Owner { get; set; }
        public IEnumerable<FieldModel> Fields { get; set; }
    }
}
