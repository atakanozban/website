using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace atakanozbancomtr.Models.classes
{
    public class admin
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<myprojects> MyProjects { get; set; }
    }
}