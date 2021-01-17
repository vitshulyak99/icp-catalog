namespace Collections.DAL.Entities
{
    public class CollectionItemTag
    {
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public CollectionItem CollectionItem { get; set; }
        public int CollectionItemId { get; set; }
    }
}