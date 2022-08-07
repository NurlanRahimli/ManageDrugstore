using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Druggist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public byte Experience { get; set; }
        public Drugstore Drugstore { get; set; }
    }
}
