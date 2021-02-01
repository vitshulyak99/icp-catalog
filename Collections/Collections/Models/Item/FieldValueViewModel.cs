
namespace Collections.Models.Item
{
    public class FieldValueViewModel :FieldValueModel
    {
        public new int FieldId => Field.Id;
        public FieldModel Field { get; set; }
    }
}