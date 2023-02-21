using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceUsuario
    {
        IEnumerable<Usuario> GetUsuario();
        //IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);
        void DeleteUsuario(int id);
        Usuario Save(Usuario usuario);
    }
}
