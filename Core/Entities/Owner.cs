using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Owner : IEntity
    {
        public Owner()
        {
            Drugstores = new List<Drugstore>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Drugstore> Drugstores { get; set; }


    }
}
