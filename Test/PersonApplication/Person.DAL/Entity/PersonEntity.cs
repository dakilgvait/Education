using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person.DAL.Entity
{
    [Table("Persons")]
    public class PersonEntity : Entity
    {
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(11)]
        public string PersonNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        public int GenderId { get; set; }
        public GenderEntity Gender { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}