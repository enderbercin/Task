using Persistance.Abstracts;
using Domain.Context;
using Persistance.Concreate;
using Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private Dictionary<Type, object> _repositories;


        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        private ProductRepository _ProductRepository;
        public IProductRepository ProductRepository => _ProductRepository = _ProductRepository ?? new ProductRepository(_context);

        private CustomerRepository _CustomerRepository;
        public ICustomerRepository CustomerRepository => _CustomerRepository = _CustomerRepository ?? new CustomerRepository(_context);

        private CustomerProductRepository _CustomerProductRepository;
        public ICustomerProductRepository CustomerProductRepository => _CustomerProductRepository = _CustomerProductRepository ?? new CustomerProductRepository(_context);


    
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
