﻿namespace ProniaOnionAB104.Domain.Entities
{
    public class Category : BaseNameableEntity
    {
        //Relational properties
        public ICollection<Product>? Products { get; set; }
    }
}
