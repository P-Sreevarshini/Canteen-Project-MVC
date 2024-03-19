﻿// Category.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}
}