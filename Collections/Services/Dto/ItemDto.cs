using System.Collections.Generic;

namespace Services.Dto
{
    public class ItemDto : BaseDto
    {
        public string Name { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<FieldValueDto> Fields { get; set; }
        public List<int> Likes { get; set; }
        public int CollectionId { get; set; }
    }
}