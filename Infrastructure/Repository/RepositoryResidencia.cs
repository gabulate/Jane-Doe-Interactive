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

        public Residencia Save(Residencia residencia)
        {
            throw new NotImplementedException();
        }
    }
}
