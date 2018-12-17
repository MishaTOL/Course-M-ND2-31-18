using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laba2.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public int StudentId { get; set; }
        [Display(Name = "News")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [Display(Name = "Date create")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        public bool OperationRecord { get; set; }

        public IEnumerable<CommentModel> CommentModels { get; set; }
        [Display(Name = "Tags")]
        public string Tags { get; set; }
    }
}