using System;

namespace Collections.Models.Comment
{
    public class CommentModel
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int ItemId { get; set; }
    }

    public class ItemSimpleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}