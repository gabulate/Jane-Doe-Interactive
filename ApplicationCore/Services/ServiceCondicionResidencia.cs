using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCondicionResidencia : IServiceCondicionResidencia
    {
        public IEnumerable<CondicionResidencia> GetCondicionResidencia()
        {
            IRepositoryCondicionResidencia repository = new RepositoryCondicionResidencia();
            return repository.GetCondicionResidencia();
        }

        public CondicionResidencia GetCondicionResidenciaById(int id)
        {
            IRepositoryCondicionResidencia repository = new RepositoryCondicionResidencia();
            return repository.GetCondicionResidenciaById(id);
        }

        public CondicionResidencia Save(CondicionResidencia condicion)
        {
            IRepositoryCondicionResidencia repository = new RepositoryCondicionResidencia();
            return repository.Save(condicion);
        }
    }
}
