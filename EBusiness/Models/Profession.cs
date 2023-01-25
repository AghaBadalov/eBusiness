﻿using System.ComponentModel.DataAnnotations;

namespace EBusiness.Models
{
    public class Profession
    {
        public int Id { get; set; }
        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
