using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTipoUsuario : IServiceTipoUsuario
    {
        public IEnumerable<TipoUsuario> GetTipoUsuario()
        {
            IRepositoryTipoUsuario repository = new RepositoryTipoUsuario();
            return repository.GetTipoUsuario();
        }

        public TipoUsuario GetTipoUsuarioByID(int id)
        {
            IRepositoryTipoUsuario repository = new RepositoryTipoUsuario();
            return repository.GetTipoUsuarioByID(id);
        }
    }
}
