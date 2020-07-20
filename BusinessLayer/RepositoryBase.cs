using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer

{
    public abstract class RepositoryBase <T> : IRepositoryBase<T> where T:class // pour que notre service implemente notre interface il doit aussi utilise les type generique T comme l'interface et il faut preciser que T doit etre une classe 
    {
        protected readonly clearnersDbContext _context;

        public RepositoryBase(clearnersDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {

            return
                _context.Set<T>(); //pour retourner les DBsets (les modeles), as not tracking pour ne pas recuperer les sous objets lors de la recuperation des données
        }

        public T FindById(Expression<Func<T, bool>> query)
        {
            try
            {
              return   _context.Set<T>().AsNoTracking().FirstOrDefault(query);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> query)
        {
            try
            {
                return _context.Set<T>().AsNoTracking().Where(query);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public T Create(T model)
        {
            try
            {
                _context.Set<T>().Add(model);
            
                _context.SaveChanges() ;
                return model;

            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public bool CreateMany(IEnumerable<T> models)
        {
            _context.Set<T>().AddRange(models);
            return _context.SaveChanges() > 0;
        }

        public bool Update(T model)
        {
           
           _context.Set<T>().Update(model);
           return _context.SaveChanges() > 0 ;
        }

        public bool UpdateMany(IEnumerable<T> models)
        {
            _context.Set<T>().UpdateRange(models);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(T model)
        {
            _context.Set<T>().Remove(model);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteMany(IEnumerable<T> models)
        {
            _context.Set<T>().RemoveRange(models);
            return _context.SaveChanges() > 0;
        }
    }
}