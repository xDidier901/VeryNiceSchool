using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public int SSN { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
