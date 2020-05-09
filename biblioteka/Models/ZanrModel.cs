﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Zanr")]
    public class ZanrModel

    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }

    }
}