using EcommerceAPI.Application.Interfaces.Repositories;
using EcommerceAPI.Application.Interfaces.UnitOfWorks;
using EcommerceAPI.Persistance.Context;
using EcommerceAPI.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();


        public int Save() => _context.SaveChanges();
        

        public async Task<int> SaveAsync()=> await _context.SaveChangesAsync();


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_context);
        

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(_context);
       
    }
}
