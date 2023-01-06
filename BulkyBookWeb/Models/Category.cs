﻿namespace BulkyBookWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int CategoryOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
