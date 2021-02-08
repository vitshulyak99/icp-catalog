using Collections.DAL.Entities.Identity;

namespace Collections.DAL.Entities
{
    public class Like
    {
        public AppUser User { get; set; }
        public Item Item { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }
}