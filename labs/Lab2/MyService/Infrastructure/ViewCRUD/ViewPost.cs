using Lab2.MyService.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.ViewCRUD
{
    public class ViewPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
    }

    public class EditPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
    }

    public class CreatPost
    {
        public int Id { get; set; }
        [DisplayName("Content")]
        public string Content { get; set; }
        [DisplayName("Author")]
        public string Author { get; set; }
        [DisplayName("Created")]
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

    }

}