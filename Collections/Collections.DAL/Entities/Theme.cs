using System.Collections.Generic;

namespace Collections.DAL.Entities
{
    public class Theme : BaseEntity
    {
        public Theme()
        {

        }
        public Theme(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Collection> Collections { get; set; }
    }
}