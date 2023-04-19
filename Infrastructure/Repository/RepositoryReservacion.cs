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
    public class RepositoryReservacion : IRepositoryReservacion
    {

        public IEnumerable<Reservacion> GetReservacionByFecha(Reservacion reservacion)
        {
            IEnumerable<Reservacion> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    //Obtiene las reservaciones que tengan la misma fecha, ya sea de inicio o final
                    lista = ctx.Reservacion
                        .Where(x => x.IdAreaComun == reservacion.IdAreaComun)
                        .Where(x => x.HoraInicio.Date == reservacion.HoraInicio.Date || 
                        x.HoraInicio.Date == reservacion.HoraFinal.Date ||
                        x.HoraFinal.Date == reservacion.HoraInicio.Date ||
                        x.HoraFinal.Date == reservacion.HoraFinal.Date)
                        .Include("AreaComun")
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

        public void DeleteReservacion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservacion> GetReservacion()
        {
            IEnumerable<Reservacion> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Reservacion
                        .Include("AreaComun")
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

        public Reservacion GetReservacionById(int id)
        {
            Reservacion reservacion = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    reservacion = ctx.Reservacion.Where(u => u.Id == id)
                        .Include("AreaComun")
                        .Include("Usuario")
                        .FirstOrDefault();
                }
                return reservacion;
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

        public IEnumerable<Reservacion> GetReservacionByUsuario(int idUsuario)
        {
            IEnumerable<Reservacion> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Reservacion
                        .Where(x => x.IdUsuario == idUsuario)
                        .Include("AreaComun")
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

        public Reservacion Save(Reservacion reservacion, int idUsuario)
        {
            int retorno = 0;
            Reservacion oReservacion = null;
            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oReservacion = GetReservacionById(reservacion.Id);

                if (oReservacion == null)
                {
                    reservacion.IdUsuario = idUsuario;
                    ctx.Reservacion.Add(reservacion);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Entry(reservacion).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }

            }

            if (retorno >= 0)
            {
                oReservacion = GetReservacionById(reservacion.Id);
            }
            return oReservacion;
        }
    }
}
