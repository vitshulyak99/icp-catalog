namespace Collections.DAL.Entities
{
    public class CustomFieldValue : BaseEntity
    {
        public string Value { get; set; }
        public CollectionItem CollectionItem { get; set; }
        public CustomField CustomField { get; set; }
        public int CollectionItemId { get; set; }
        public int CustomFieldId { get; set; }
    }
}