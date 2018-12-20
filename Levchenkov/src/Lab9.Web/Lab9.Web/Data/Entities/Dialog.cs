using System.Collections.Generic;

namespace Lab9.Web.Data.Entities
{
    public class Dialog
    {
        public int Id
        {
            get;
            set;
        }

        public virtual IEnumerable<UserDialog> UserDialogs
        {
            get;
            set;
        }

        public virtual IEnumerable<Message> Messages
        {
            get;
            set;
        }
    }
}
