﻿using Infrastructure.Models;
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
                        Include("PlanCobro").Include("Residencia").Include("Usuario").
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


        public Deuda GetDeudaByIdResidencia(int idResidencia)
        {
            Deuda deuda = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    deuda = ctx.Deuda.
                        Where(u => u.IdResidencia == idResidencia).
                        Include("PlanCobro").Include("Residencia").Include("Usuario").
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

        public Deuda Save(Deuda deuda)
        {
            throw new NotImplementedException();
        }
    }
}
