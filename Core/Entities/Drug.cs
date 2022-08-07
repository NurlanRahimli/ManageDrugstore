using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Drug : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Drugstore Drugstore { get; set; }
    }
}
