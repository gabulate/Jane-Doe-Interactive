using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Web.Security
{
    public class AuthorizeView
    {
        public static bool IsUserInRole(string[] nombreTipos)
        {
            IEnumerable<Roles> allowedTipos = nombreTipos.
                Select(a => (Roles)Enum.Parse(typeof(Roles), a));
            bool authorize = false;
            var oUsuario = (Usuario)HttpContext.Current.Session["User"];
            if (oUsuario != null)
            {
                foreach (var tipo in allowedTipos)
                {
                    if ((int)tipo == oUsuario.IdTipoUsuario)
                        return true;
                }
            }
            return authorize;
        }
    }
}