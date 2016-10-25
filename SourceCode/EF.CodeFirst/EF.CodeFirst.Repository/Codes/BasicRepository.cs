
namespace EF.CodeFirst.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public interface IBasicRepository<T> where T : class, new()
    {
        BasicContext Context { get; set; }

        bool IsAutoCommit { get; set; }

        IEnumerable<T> View { get; }

        T Select(params object[] keys);

        T Create();

        int Insert(T entity);

        int Update(T entity);

        int Update(T entity, params object[] keys);

        int Delete(T entity);

        int Delete(params object[] keys);
    }

    public partial class BasicRepository<T> : IDisposable, IBasicRepository<T> where T : class, new()
    {
        protected virtual void Dispose(bool isDispose)
        {
            if (!isDispose)
            {
                return;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BasicContext Context { get; set; }

        public bool IsAutoCommit { get; set; }

        public BasicRepository()
        {
            Context = new BasicContext();
            IsAutoCommit = true;
        }

        public BasicRepository(BasicContext context)
        {
            Context = context;
            IsAutoCommit = false;
        }

        public IEnumerable<T> View
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public T Select(params object[] keys)
        {

            return Context.Set<T>().Find(keys);
        }

        public T Create()
        {
            return Context.Set<T>().Create();
        }

        public int Insert(T entity)
        {
            Context.Set<T>().Add(entity);
            return IsAutoCommit ? Context.SaveChanges() : 0;
        }

        public int Update(T entity)
        {
            var state = Context.Entry(entity).State;
            if (state != EntityState.Modified)
            {
                return 0;
            }

            return IsAutoCommit ? Context.SaveChanges() : 0;
        }

        public int Update(T entity, params object[] keys)
        {
            var original = Select(keys);
            if (original == null)
            {
                return 0;
            }

            Context.Entry(original).CurrentValues.SetValues(entity);

            return Update(entity);
        }

        public int Delete(T entity)
        {
            Context.Set<T>().Remove(entity);

            return IsAutoCommit ? Context.SaveChanges() : 0;
        }

        public int Delete(params object[] keys)
        {
            var original = Select(keys);
            if (original == null)
            {
                return 0;
            }

            return Delete(original);
        }
    }
}
