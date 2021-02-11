using Collections.DAL.Entities.Enums;

namespace Services.Dto
{
    public class FieldDto : BaseDto
    {
        public string Name { get; set; }
        public FieldType Type { get; set; }
    }
}