using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Utils;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public void DeleteUsuario(int id)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            rep.DeleteUsuario(id);
        }

        //Función que escribí para encriptar todas las contraseñas que
        //ya estaban en la base de datos
        public void EncryptarContrasenas()
        {
            IEnumerable<Usuario> lista = GetUsuario();

            foreach(Usuario u in lista)
            {
                Save(u);
            }
        }

        public IEnumerable<Usuario> GetUsuario()
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            return rep.GetUsuario();
        }

        public Usuario GetUsuario(string email, string contrasenna)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            // Encriptar el password para poder compararlo

            string cryptPassword = Cryptography.EncrypthAES(contrasenna);

            return rep.GetUsuario(email, cryptPassword);
        }

        public Usuario GetUsuarioById(int id)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            Usuario oUsuario = rep.GetUsuarioById(id);
            // Desencriptar el password para presentarlo
            oUsuario.Contrasenna = Cryptography.DecrypthAES(oUsuario.Contrasenna);
            return oUsuario;
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario rep = new RepositoryUsuario();
            // Encriptar el password para guardarlo
            usuario.Contrasenna = Cryptography.EncrypthAES(usuario.Contrasenna);

            return rep.Save(usuario);
        }
    }
}
