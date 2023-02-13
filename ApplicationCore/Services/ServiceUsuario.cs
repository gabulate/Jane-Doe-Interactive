using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public void DeleteUsuario(int id)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            rep.DeleteUsuario(id);
        }

        public IEnumerable<Usuario> GetUsuario()
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            return rep.GetUsuario();
        }

        public Usuario GetUsuarioById(int id)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            return rep.GetUsuarioById(id);
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            return rep.Save(usuario);
        }
    }
}
