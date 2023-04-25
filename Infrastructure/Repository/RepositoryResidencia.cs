using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public void DeleteResidencia(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Residencia> GetResidencia()
        {
            IEnumerable<Residencia> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos las residencias incluyendo el propietario
                    lista = ctx.Residencia.Include("Usuario")
                        .Include("CondicionResidencia")
                        .Include("Deuda")
                        .Include("Deuda.PlanCobro")
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

        public Residencia GetResidenciaById(int id)
        {
            Residencia residencia = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    residencia = ctx.Residencia
                        .Where(r => r.Id == id)
                        .Include("Usuario")
                        .Include("CondicionResidencia")
                        .Include("Deuda")
                        .Include("Deuda.PlanCobro")
                        .FirstOrDefault();
                }
                return residencia;
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

        public IEnumerable<Residencia> GetResidenciaByUsuario(int id)
        {
            IEnumerable<Residencia> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos las residencias incluyendo el propietario
                    lista = ctx.Residencia
                        .Where(x => x.Propietario == id)
                        .Include("Usuario")
                        .Include("CondicionResidencia")
                        .Include("Deuda")
                        .Include("Deuda.PlanCobro")
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

        public Residencia Save(Residencia residencia)
        {
            int retorno = 0;
            Residencia oResidencia = null;
            using(MyContext ctx= new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oResidencia = GetResidenciaById(residencia.Id);

                if(oResidencia == null)
                {
                    residencia.Condicion = 3; //Condición: "En venta"
                    residencia.Propietario = 14; //Usuario de la dueña del condominio: Jane Doe
                    residencia.AnioConstrucion = null;
                    residencia.Habitantes = 0;
                    ctx.Residencia.Add(residencia);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Entry(residencia).State=EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }
            if(retorno >= 0)
            {
                oResidencia = GetResidenciaById(residencia.Id);
            }
            return oResidencia;
        }
    }
}
