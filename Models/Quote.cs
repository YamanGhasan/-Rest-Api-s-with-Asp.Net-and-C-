﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quotesApiCourse.Models
{
    public class Quote
    {

        //  create properties  "prop + tab"
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Title { get; set; }
        [Required]
        [StringLength(25)]
        public string Author { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
      
}
}