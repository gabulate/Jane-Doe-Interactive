using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceResidencia : IServiceResidencia
    {
        public void DeleteResidencia(int id)
        {
            IRepositoryResidencia rep = new RepositoryResidencia();
            rep.DeleteResidencia(id);
        }

        public IEnumerable<Residencia> GetResidencia()
        {
            IRepositoryResidencia rep = new RepositoryResidencia();
            return rep.GetResidencia();
        }

        public Residencia GetResidenciaById(int id)
        {
            IRepositoryResidencia rep = new RepositoryResidencia();
            return rep.GetResidenciaById(id);
        }

        public IEnumerable<Residencia> GetResidenciaByUsuario(int id)
        {
            IRepositoryResidencia rep = new RepositoryResidencia();
            return rep.GetResidenciaByUsuario(id);
        }

        public Residencia Save(Residencia residencia)
        {
            IRepositoryResidencia rep = new RepositoryResidencia();
            return rep.Save(residencia);
        }
    }
}
