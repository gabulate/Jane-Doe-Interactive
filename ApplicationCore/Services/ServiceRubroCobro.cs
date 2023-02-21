using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRubroCobro : IServiceRubroCobro
    {
        public IEnumerable<RubroCobro> GetRubroCobro()
        {
            IRepositoryRubroCobro repository = new RepositoryRubroCobro();
            return repository.GetRubroCobro();
        }
        public RubroCobro GetRubroCobroByID(int id)
        {
            IRepositoryRubroCobro repository = new RepositoryRubroCobro();
            return repository.GetRubroCobroByID(id);
        }
    }
}
