using System;
using System.ComponentModel.DataAnnotations;

namespace Person.DTO
{
    public class PersonViewModel : PersonBaeModel
    {
        public int Id { get; set; }

        public string Gender { get; set; }
    }
}