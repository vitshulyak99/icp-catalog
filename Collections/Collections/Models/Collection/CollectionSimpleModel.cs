namespace Collections.Models.Collection
{
    public class CollectionSimpleModel : CollectionModel
    {
        public int Id { get; set; }

        public int ItemsCount { get; set; }
        public SimpleUserInfoModel Owner { get; set; }
    }
}
