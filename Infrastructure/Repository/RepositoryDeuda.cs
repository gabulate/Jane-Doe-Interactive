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
    public class RepositoryDeuda : IRepositoryDeuda
    {
        public void DeleteDeuda(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deuda> GetDeuda()
        {
            IEnumerable<Deuda> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Deuda.
                        Include("PlanCobro").Include("Residencia").Include("Residencia.Usuario").
                        ToList();

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

        public IEnumerable<Deuda> GetDeudaPendiente()
        {
            IEnumerable<Deuda> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Deuda
                        .Where(x => x.PendientePago == true)
                        .Include("PlanCobro")
                        .Include("Residencia")
                        .Include("Residencia.Usuario")
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

        public Deuda GetDeudaById(int id)
        {
            Deuda deuda = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    deuda = ctx.Deuda.
                        Where(u => u.Id == id).
                        Include("PlanCobro").Include("Residencia").Include("Residencia.Usuario").
                        FirstOrDefault();
                }
                return deuda;
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

        public IEnumerable<Deuda> GetDeudaByUsuario(int id)
        {
            IEnumerable<Deuda> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los Usuarios incluyendo el autor
                    lista = ctx.Deuda
                        .Where(u => u.Residencia.Usuario.Id == id)
                        .Include("PlanCobro")
                        .Include("Residencia")
                        .Include("Residencia.Usuario")
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

        public Deuda Save(Deuda deuda)
        {
            int retorno = 0;
            Deuda oDeuda = null;


            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oDeuda = GetDeudaById(deuda.Id);
                IRepositoryPlanCobro _RepositoryPlanCobro= new RepositoryPlanCobro();

                if (oDeuda == null)
                {
                    //Busca si hay una entrada con el mes y el año igual en la misma residencia
                    bool existeEntrada = ctx.Deuda
                                        .Where(d => d.IdResidencia == deuda.IdResidencia)
                                        .Any(d => d.Fecha.Month == deuda.Fecha.Month &&
                                                  d.Fecha.Year == deuda.Fecha.Year);
                    // si no existe, se agrega
                    if (!existeEntrada)
                    {
                        deuda.PendientePago= true; //valor default: todos los pagos estarán pendientes hasta que se modifique manualmente
                        ctx.Deuda.Add(deuda);
                        retorno = ctx.SaveChanges();
                    }
                }
                else
                {
                    
                    //ctx.Incidente.Add(incidente);
                    ctx.Entry(deuda).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }

            }

            if (retorno >= 0)
            {
                oDeuda = GetDeudaById(deuda.Id);
            }
            return oDeuda;
        }
    }
}
