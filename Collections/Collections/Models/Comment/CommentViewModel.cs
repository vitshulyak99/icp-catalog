namespace Collections.Models.Comment
{
    public class CommentViewModel : CommentModel
    {
        public SimpleUserInfoModel Sender { get; set; }
        public ItemSimpleViewModel Item { get; set; }
    }
}