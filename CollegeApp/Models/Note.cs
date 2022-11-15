using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApp.Models
{
    public class Note
    {
        public int id { get; set; }
        [Required]
        public string noteTitle { get; set; }
        [Required]
        public string noteDesc { get; set; }

        
    }
}
