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
    public class RepositoryIncidente : IRepositoryIncidente
    {
        public void DeleteIncidente(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Incidente> GetIncidente()
        {
            IEnumerable<Incidente> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Incidente
                        .Include("EstadoIncidente")
                        .Include("Usuario")
                        .ToList();

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

        public IEnumerable<Incidente> GetIncidenteByUsuario(int idUsuario)
        {
            IEnumerable<Incidente> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Incidente
                        .Where(x => x.IdUsuario == idUsuario)
                        .Include("EstadoIncidente")
                        .Include("Usuario")
                        .ToList();

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

        public Incidente GetIncidenteById(int id)
        {
            Incidente incidente = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    incidente = ctx.Incidente.Where(u => u.Id == id)
                        .Include("EstadoIncidente")
                        .Include("Usuario")
                        .FirstOrDefault();
                }
                return incidente;
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

        public Incidente Save(Incidente incidente)
        {
            int retorno = 0;
            Incidente oIncidente = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oIncidente = GetIncidenteById((int)incidente.Id);

                if (oIncidente == null)
                {
                    incidente.IdUsuario = 1;
                    incidente.Estado = 1;
                    ctx.Incidente.Add(incidente);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    oIncidente.Estado = incidente.Estado;

                    ctx.Incidente.Add(oIncidente);
                    ctx.Entry(oIncidente).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }

            }

            if (retorno >= 0)
            {
                oIncidente = GetIncidenteById((int)incidente.Id);
            }
            return oIncidente;
        }
    }
}
