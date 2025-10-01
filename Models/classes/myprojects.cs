using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace atakanozbancomtr.Models.classes
{
    public class myprojects
    {
        [Key]
        public int id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string iframe { get; set; }
        public object admins { get; internal set; }
    }
}