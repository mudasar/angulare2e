using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJsTodo.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [MaxLength(800,ErrorMessage = "text could be 800 characters long")]
        public string Text { get; set; }
        public int Priority { get; set; }
        public DateTime? DueDate { get; set; }

    }
}