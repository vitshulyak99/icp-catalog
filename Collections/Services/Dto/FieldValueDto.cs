namespace Services.Dto
{
    public class FieldValueDto : BaseDto
    {
        public FieldDto Field { get; set; }
        public string Value { get; set; }
    }
}