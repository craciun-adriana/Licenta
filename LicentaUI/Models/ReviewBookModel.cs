using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaUI.Models
{
    public class ReviewBookModel
    {
        public string ID { get; set; }

        public string IdUser { get; set; }

        public string IdBook { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}