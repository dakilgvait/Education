using System;
using System.ComponentModel.DataAnnotations;

namespace Person.DTO
{
    public class PersonNewModel : PersonBaeModel
    {
        public int Gender { get; set; }
    }
}