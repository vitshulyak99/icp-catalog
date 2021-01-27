namespace Collections.Models.Collection
{
    public class CollectionCreateModel : CollectionModel
    {
        public FieldCreateModel[] Fields { get; set; }
        public string OwnerName { get; set; }
    }
}