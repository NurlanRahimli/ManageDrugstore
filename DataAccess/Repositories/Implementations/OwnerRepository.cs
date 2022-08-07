using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Implementations
{
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;
        public void Create(Owner entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Owners.Add(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Delete(Owner entity)
        {
            try
            {
                DbContext.Owners.Remove(entity);

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(Owner entity)
        {
            try
            {
                var owner = DbContext.Owners.Find(d => d.Id == entity.Id);
                if (owner != null)
                {
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Owners[0];
                }
                else
                {
                    return DbContext.Owners.Find((Predicate<Owner>)filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Owners;
                }
                else
                {
                    return DbContext.Owners.FindAll(filter);
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
