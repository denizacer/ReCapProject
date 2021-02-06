using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public EfCarDal()
        {
        }

        public void Add(Car entity)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var addedEntity = context.Entry(entity);//veri kaynağıla eşleşti
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var deletedEntity = context.Entry(entity);//veri kaynağıla eşleşti
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDemoContext context = new ReCapDemoContext())
            {
                var uptadedEntity = context.Entry(entity);//veri kaynağıla eşleşti
                uptadedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

       
    }
}
