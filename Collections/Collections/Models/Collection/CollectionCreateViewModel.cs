using System.Collections.Generic;
using System.Linq;
using Collections.DAL.Entities.Enums;
using static System.Enum;

namespace Collections.Models.Collection
{
    public class CollectionCreateViewModel
    {
        public CollectionCreateViewModel() => Types = GetValues<FieldType>().ToList();

        public List<FieldType> Types { get; set; }

        public List<ThemeModel> Themes;
    }
}