using Collections.DAL.Entities.Enums;

namespace Collections.Models.Collection
{
    public class FieldCreateModel
    {

        public FieldCreateModel()
        {
            
        }

        public FieldType Type { get; set; }
        public string Name { get; set; }
    }
}