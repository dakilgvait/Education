﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Person.DTO
{
    public class PersonEditModel : PersonBaeModel
    {
        public int Id { get; set; }

        public int Gender { get; set; }
    }
}