using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DealDouble.Entities.Entities;

namespace DealDouble.Services.IRepository
{
    public interface IProductionRepository : IRepository<Production>
    {

        Task<IEnumerable<Production>> GetLast3Production();
    }
}
