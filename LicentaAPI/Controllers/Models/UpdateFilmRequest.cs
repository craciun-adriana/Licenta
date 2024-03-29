﻿using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers.Models
{
    public class UpdateFilmRequest
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}