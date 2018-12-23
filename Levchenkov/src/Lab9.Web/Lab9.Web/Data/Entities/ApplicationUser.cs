using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Lab9.Web.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserProfileId
        {
            get;
            set;
        }

        public virtual UserProfile UserProfile
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

        public virtual IEnumerable<Post> Posts
        {
            get;
            set;
        }

        public virtual IEnumerable<Friend> Friends
        {
            get;
            set;
        }

        public virtual IEnumerable<Comment> Comments
        {
            get;
            set;
        }
    }


}
