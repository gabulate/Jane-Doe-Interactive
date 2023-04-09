using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryUsuario
    {
        IEnumerable<Usuario> GetUsuario();
        Usuario GetUsuarioById(int id);
        void DeleteUsuario(int id);
        Usuario Save(Usuario usuario);
        Usuario GetUsuario(string email, string contrasenna);
    }
}
