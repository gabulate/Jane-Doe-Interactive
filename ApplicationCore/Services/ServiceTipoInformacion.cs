using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoInformacion : IServiceTipoInformación
    {
        public void DeleteTipo(int id)
        {
            IRepositoryTipoInformacion repository = new RepositoryTipoInformacion();
            repository.DeleteTipo(id);
        }

        public TipoInformacion GetTipoById(int id)
        {
            IRepositoryTipoInformacion repository = new RepositoryTipoInformacion();
            return repository.GetTipoById(id);
        }

        public IEnumerable<TipoInformacion> GetTipoInformacion()
        {
            IRepositoryTipoInformacion repository = new RepositoryTipoInformacion();
            return repository.GetTipoInformacion();
        }

        public TipoInformacion Save(TipoInformacion tipo)
        {
            IRepositoryTipoInformacion repository = new RepositoryTipoInformacion();
            return repository.Save(tipo);
        }
    }
}
