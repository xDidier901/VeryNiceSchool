using Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }


        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
