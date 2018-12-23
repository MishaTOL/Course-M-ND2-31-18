namespace Lab9.Web.Data.Entities
{
    public class UserDialog
    {
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

        public int DialogId
        {
            get;
            set;
        }

        public virtual Dialog Dialog
        {
            get;
            set;
        }
    }
}
