﻿namespace ApiProjeKampi.WebApi.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Product> products { get; set; }
    }
}
