namespace Lab9.Web.Data.Entities
{
    public class Friend
    {
        public string SourceUserId
        {
            get;
            set;
        }

        public virtual ApplicationUser SourceUser
        {
            get;
            set;
        }

        public string TargetUserId
        {
            get;
            set;
        }

        public virtual ApplicationUser TargetUser
        {
            get;
            set;
        }

        public bool IsConfirmed
        {
            get;
            set;
        }
    }


}
