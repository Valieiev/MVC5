﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRACTICK3.ViewModels
{
    public class BoardgameViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Coast { get; set; }
        public int Rang { get; set; }
        public int Count { get; set; }
        
        [Display(Name = "ProductName")]
        [Required(ErrorMessage = ("Game Name is required.")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Name { get; set; }
    }
}