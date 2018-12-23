namespace Lab9.Web.Data.Entities
{
    public class UserProfile
    {
        public int Id
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

        public string Avatar
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
    }
}
