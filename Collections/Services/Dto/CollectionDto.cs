using System.Collections.Generic;

namespace Services.Dto  
{
    public class CollectionDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<FieldDto> Fields { get; set; } = new();
        public UserDto Owner { get; set; } = new();
        public ThemeDto Theme { get; set; } = new();
    }
}