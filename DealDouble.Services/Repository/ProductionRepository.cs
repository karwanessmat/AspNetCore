using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealDouble.Data.DAL;
using DealDouble.Entities.Entities;
using DealDouble.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DealDouble.Services.Repository
{
   public class ProductionRepository:Repository<Production>, IProductionRepository
    {
        public ProductionRepository(DealDoubleContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Production>> GetLast3Production()
        {
            return await Context.Productions.OrderBy(x => x.Id).Take(3).ToListAsync();
        }
    }
}
