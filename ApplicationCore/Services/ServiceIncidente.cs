using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceIncidente : IServiceIncidente
    {
        public void DeleteIncidente(int id)
        {
            IRepositoryIncidente repository = new RepositoryIncidente();
            repository.DeleteIncidente(id);
        }

        public IEnumerable<Incidente> GetIncidente()
        {
            IRepositoryIncidente repository = new RepositoryIncidente();
            return repository.GetIncidente();
        }

        public Incidente GetIncidenteById(int id)
        {
            IRepositoryIncidente repository = new RepositoryIncidente();
            return repository.GetIncidenteById(id);
        }

        public IEnumerable<Incidente> GetIncidenteByUsuario(int idUsuario)
        {
            IRepositoryIncidente repository = new RepositoryIncidente();
            return repository.GetIncidenteByUsuario(idUsuario);
        }

        public Incidente Save(Incidente incidente, int idUsuario)
        {
            IRepositoryIncidente repository = new RepositoryIncidente();
            return repository.Save(incidente, idUsuario);
        }
    }
}
