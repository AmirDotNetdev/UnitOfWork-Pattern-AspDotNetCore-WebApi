using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class UnitOfWorks : IUnitOfWorks
    {
        ApplicationDBContext _context;
        private IGenericRepository<Stock> _stock;
        private IGenericRepository<Comment> _comment;
        public UnitOfWorks(ApplicationDBContext context)
        {
            _context = context;
        }
        public IGenericRepository<Stock> Stocks => _stock ??= new GenericRepository<Stock>(_context);

        public IGenericRepository<Comment> Comments =>  _comment ??= new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}