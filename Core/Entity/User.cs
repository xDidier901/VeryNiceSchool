using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required, MinLength(4)]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] Salt { get; set; }
        public string Email { get; set; }
        [Required]
        public UserType Type { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
