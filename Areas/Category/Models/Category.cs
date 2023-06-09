﻿namespace ECommerce.Areas.Category.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        public String CategoryName { get; set; }
        public DateTime CreatedON { get; set; }
    }

    public class CategoryDropdown
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
    }
}
