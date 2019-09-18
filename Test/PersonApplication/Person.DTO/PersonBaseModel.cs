using System;
using System.ComponentModel.DataAnnotations;

namespace Person.DTO
{
    public class PersonBaeModel
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string PersonNumber { get; set; }

        public DateTime Birthdate { get; set; }

        [Range(0, 999999999.99)]
        public decimal Salary { get; set; }
    }
}