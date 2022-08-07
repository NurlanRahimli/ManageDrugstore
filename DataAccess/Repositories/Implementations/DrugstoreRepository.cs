using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Implementations
{
    public class DrugstoreRepository : IRepository<Drugstore>
    {
        private static int id;
        public void Create(Drugstore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugstores.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Delete(Drugstore entity)
        {
            try
            {
                DbContext.Drugstores.Remove(entity);

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(Drugstore entity)
        {
            try
            {
                var drugstore = DbContext.Drugstores.Find(d => d.Id == entity.Id);
                if (drugstore != null)
                {
                    drugstore.Name = entity.Name;
                    drugstore.Address = entity.Address;
                    drugstore.ContactNumber = entity.ContactNumber;
                    drugstore.Druggists = entity.Druggists;
                    drugstore.Drugs = entity.Drugs;
                    drugstore.Owner = entity.Owner;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Drugstore Get(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugstores[0];
                }
                else
                {
                    return DbContext.Drugstores.Find((Predicate<Drugstore>)filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Drugstore> GetAll(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugstores;
                }
                else
                {
                    return DbContext.Drugstores.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Delete(Druggist druggist)
        {
            try
            {
                DbContext.Druggists.Remove(druggist);

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
