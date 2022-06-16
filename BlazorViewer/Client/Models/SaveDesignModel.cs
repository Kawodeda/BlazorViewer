﻿using System.ComponentModel.DataAnnotations;

namespace BlazorViewer.Client.Models
{
    public class SaveDesignModel
    {
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Name is too long")]
        public string? Name { get; set; }
    }
}
