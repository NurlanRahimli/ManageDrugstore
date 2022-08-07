using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Implementations
{
    public class DrugRepository : IRepository<Drug>
    {
        private static int id;
        public void Create(Drug entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugs.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Delete(Drug entity)
        {
            try
            {
                DbContext.Drugs.Remove(entity);

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(Drug entity)
        {
            try
            {
                var drug = DbContext.Drugs.Find(d => d.Id == entity.Id);
                if (drug != null)
                {
                    drug.Name = entity.Name;
                    drug.Price = entity.Price;
                    drug.Count = entity.Count;
                    drug.Drugstore = entity.Drugstore;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Drug Get(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs[0];
                }
                else
                {
                    return DbContext.Drugs.Find((Predicate<Drug>)filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs;
                }
                else
                {
                    return DbContext.Drugs.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

    }
}
