using System.Collections.Generic;

namespace Collections.Models.Collection
{
    public class CollectionEditViewModel : CollectionModel
    {
        public int Id { get; set; }
        public List<ThemeModel> Themes { get; set; }
    }
}