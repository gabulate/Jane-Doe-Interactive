using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoIncidente : IServiceEstadoIncidente
    {
        public void DeleteEstado(int id)
        {
            IRepositoryEstadoIncidente repositoryEstado = new RepositoryEstadoIncidente();
            repositoryEstado.DeleteEstado(id);
        }

        public EstadoIncidente GetEstadoById(int id)
        {
            IRepositoryEstadoIncidente repositoryEstado = new RepositoryEstadoIncidente();
            return repositoryEstado.GetEstadoById(id);
        }

        public IEnumerable<EstadoIncidente> GetEstadoIncidente()
        {
            IRepositoryEstadoIncidente repositoryEstado = new RepositoryEstadoIncidente();
            return repositoryEstado.GetEstadoIncidente();
        }

        public EstadoIncidente Save(EstadoIncidente estado)
        {
            IRepositoryEstadoIncidente repositoryEstado = new RepositoryEstadoIncidente();
            return repositoryEstado.Save(estado);
        }
    }
}
