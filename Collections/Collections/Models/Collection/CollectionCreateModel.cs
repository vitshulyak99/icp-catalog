using System.ComponentModel.DataAnnotations;

namespace Collections.Models.Collection
{
    public class CollectionCreateModel 
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Theme { get; set; }
        [Required]
        public string Description { get; set; }

        public FieldCreateModel[] Fields { get; set; } = new FieldCreateModel[0];
    }
}