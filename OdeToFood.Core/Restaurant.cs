using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        [Required, StringLength(255)]
        public String Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
