using DBModels.Models;
using DBRepConUow.Context;
using DBRepConUow.Repositarys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepConUow.UnitOfWork
{
    public class ForumUOW: IForumUOW, IDisposable
    {
        private ForumContext db;
        private bool disposed = false;
        private IRepositary<int, Student> studentRepositary;
        private IRepositary<int, Post> postRepositary;
        private IRepositary<int, Comment> commentRepositary;
        private IRepositary<int, Tag> tagRepositary;

        public ForumUOW(ForumContext forumContext) 
        {
            this.db = new ForumContext();
        }
        
        public IRepositary<int, Student> StudentRepositary
        {
            get
            {
                studentRepositary = studentRepositary ?? new StudentRepositary(db);
                return studentRepositary;
            }
        }

        public IRepositary<int, Post> PostRepositary
        {
            get
            {
                postRepositary = postRepositary ?? new PostRepositary(db);
                return postRepositary;
            }
        }

        public IRepositary<int, Comment> CommentRepositary
        {
            get
            {
                commentRepositary = commentRepositary ?? new CommentRepositary(db);
                return commentRepositary;
            }
        } 

        public IRepositary<int, Tag> TagRepositary
        {
            get
            {
                tagRepositary = tagRepositary ?? new TagRepositary(db);
                return tagRepositary;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
