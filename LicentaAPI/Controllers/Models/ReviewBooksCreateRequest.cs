﻿using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers.Models
{
    public class ReviewBooksCreateRequest
    {
        [Required]
        public string IdBook { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}