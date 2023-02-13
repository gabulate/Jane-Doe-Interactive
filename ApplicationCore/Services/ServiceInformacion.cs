using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceInformacion : IServiceInformacion
    {
        public void DeleteInformacion(int id)
        {
            IRepositoryInformacion rep = new RepositoryInformacion();
            rep.DeleteInformacion(id);
        }

        public IEnumerable<Informacion> GetInformacion()
        {
            IRepositoryInformacion rep = new RepositoryInformacion();
            return rep.GetInformacion();
        }

        public Informacion GetInformacionById(int id)
        {
            IRepositoryInformacion rep = new RepositoryInformacion();
            return rep.GetInformacionById(id);
        }

        public Informacion Save(Informacion informacion)
        {
            IRepositoryInformacion rep = new RepositoryInformacion();
            return rep.Save(informacion);
        }
    }
}
