﻿namespace Catalog.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        public string Summary { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
