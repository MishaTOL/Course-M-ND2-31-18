namespace Lab9.Web.Data.Entities
{
    public class CommentLike
    {
        public int CommentId
        {
            get;
            set;
        }

        public virtual Comment Comment
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public virtual ApplicationUser User
        {
            get;
            set;
        }
    }

}
