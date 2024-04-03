using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUnitOfWorks : IDisposable
    {
        IGenericRepository<Stock> Stocks{get;}
        IGenericRepository<Comment> Comments{get;}
        Task SaveAsync();
        
    }
}