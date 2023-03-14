using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryInformacion : IRepositoryInformacion
    {
        public void DeleteInformacion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Informacion> GetInformacion()
        {
            IEnumerable<Informacion> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Informacion.Include("TipoInformacion").ToList();

                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Informacion GetInformacionById(int id)
        {
            Informacion info = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    info = ctx.Informacion.Where(u => u.Id == id).Include("TipoInformacion").FirstOrDefault();
                }
                return info;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Informacion Save(Informacion informacion)
            {
            int retorno = 0;
            Informacion oInformacion = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oInformacion = GetInformacionById((int)informacion.Id);

                if (oInformacion == null)
                {
                    ctx.Informacion.Add(informacion);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Informacion.Add(informacion);
                    ctx.Entry(informacion).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }

            }

            if (retorno >= 0)
            {
                oInformacion = GetInformacionById((int)informacion.Id);
            }
            return oInformacion;
        }
    }
}
