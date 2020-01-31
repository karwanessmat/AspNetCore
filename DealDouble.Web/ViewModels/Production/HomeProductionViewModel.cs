using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealDouble.Web.ViewModels.Production
{
    public class HomeProductionViewModel
    {
        public IEnumerable<Entities.Entities.Production> Productions { get; set; }
        public IEnumerable<Entities.Entities.Production> Last3Productions { get; set; }
    }
}
