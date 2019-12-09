using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        [Required, MinLength(4)]
        public string Name { get; set; }
        public int Credits { get; set; }
        public int InstructorID { get; set; }
        public bool IsActive { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
