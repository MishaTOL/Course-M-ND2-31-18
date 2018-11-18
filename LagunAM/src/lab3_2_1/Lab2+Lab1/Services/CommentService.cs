using AutoMapper;
using DBModels.Models;
using DBRepConUow.Repositarys;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.InfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.Services
{
    public class CommentService:IService<Comment>
    {
        private IForumUOW forumUOW;
        private CommentInfo CommentToCommentInfo(Comment comment)
        {
            return Mapper.Map<Comment, CommentInfo>(comment);
        }
        private Comment CommentInfoToComment(CommentInfo commentInfo)
        {
            return Mapper.Map<CommentInfo, Comment>(commentInfo);
        }

        public CommentService(IForumUOW forumUOW)
        {
            this.forumUOW = forumUOW;
        }
        public IEnumerable<CommentInfo> GetComments(CommentInfo commentInfo)
        {
            var comments = forumUOW.PostRepositary.Get(commentInfo.PostId).Comments;
            var result = new List<CommentInfo>();
            foreach (var item in comments)
            {
                result.Add(
                    CommentToCommentInfo(item));
            }
            return result;
        }
        public void Add(CommentInfo commentInfo)
        {
            commentInfo.Created = DateTime.Now;
            forumUOW.CommentRepositary.Add(
                CommentInfoToComment(commentInfo));
            forumUOW.Save();
        }
        public void Edit(CommentInfo commentInfo)
        {
            Comment comment = forumUOW.CommentRepositary.Get(commentInfo.CommentId);
            comment.Content = commentInfo.Content;
            forumUOW.CommentRepositary.Update(comment);
            forumUOW.Save();
        }
        public CommentInfo GetPost(CommentInfo commentInfo)
        {
            Post post = forumUOW.PostRepositary.Get(commentInfo.PostId);
            return Mapper.Map<Post, CommentInfo>(post);
        }
        public void DeleteById(CommentInfo commentInfo)
        {
            ((CommentRepositary)(forumUOW.CommentRepositary)).DeleteById(commentInfo.CommentId);
            forumUOW.Save();
        }

    }
}