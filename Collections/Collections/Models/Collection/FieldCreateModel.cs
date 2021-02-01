using System.Text.Json.Serialization;
using Collections.DAL.Entities.Enums;

namespace Collections.Models.Collection
{
    public class FieldCreateModel
    {

        public FieldCreateModel()
        {
            
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FieldType Type { get; set; }
        public string Name { get; set; }
    }
}