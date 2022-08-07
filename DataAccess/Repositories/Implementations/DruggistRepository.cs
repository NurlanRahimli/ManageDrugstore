using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Implementations
{
    public class DruggistRepository : IRepository<Druggist>
    {
        private static int id;
        public void Create(Druggist entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Druggists.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Delete(Druggist entity)
        {
            try
            {
                DbContext.Druggists.Remove(entity);

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(Druggist entity)
        {
            try
            {
                var druggist = DbContext.Druggists.Find(d => d.Id == entity.Id);
                if (druggist != null)
                {
                    druggist.Name = entity.Name;
                    druggist.Surname = entity.Surname;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Druggist Get(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Druggists[0];
                }
                else
                {
                    return DbContext.Druggists.Find((Predicate<Druggist>)filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Druggist> GetAll(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Druggists;
                }
                else
                {
                    return DbContext.Druggists.FindAll(filter);
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
