using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Business.Abstraction
{
    public interface ITagService
    {
        void AddTag(int postId, Tag tag);
        int DeleteTag(int tagId, int postId);
        List<Tag> GetTags(int postId);
    }
}
