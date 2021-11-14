using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models;

namespace WebApplication14.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private OrderContext context = new OrderContext();
        private GenericRepository<Order> OrderRepository;

        public GenericRepository<Order> OrdersRepository
        {
            get
            {

                if (this.OrderRepository == null)
                {
                    this.OrderRepository = new GenericRepository<Order>(context);
                }
                return OrderRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}