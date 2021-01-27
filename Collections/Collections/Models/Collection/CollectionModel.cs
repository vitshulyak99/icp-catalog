namespace Collections.Models.Collection
{
    public abstract class CollectionModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ThemeModel Theme { get; set; }
        public string Description { get; set; }
    }
}
