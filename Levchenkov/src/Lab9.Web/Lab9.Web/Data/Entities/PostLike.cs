namespace Lab9.Web.Data.Entities
{
    public class PostLike
    {
        public int PostId
        {
            get;
            set;
        }

        public virtual Post Post
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
