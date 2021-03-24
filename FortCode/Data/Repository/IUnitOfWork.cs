using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Data.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        DataContext context { get; }
    }
}
