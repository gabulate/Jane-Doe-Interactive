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
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public void DeletePlanCobro(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanCobro> GetPlanCobro()
        {
            IEnumerable<PlanCobro> lista = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    //lista= from plan in ctx.PlanCobro select plan;

                    lista = ctx.PlanCobro.
                        Include("RubroCobro").ToList();
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

        public PlanCobro GetPlanCobroByID(int id)
        {
            PlanCobro planCobro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    planCobro = ctx.PlanCobro.
                        Where(p => p.Id == id).
                        Include("RubroCobro").
                        FirstOrDefault();
                }
                return planCobro;
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

        public PlanCobro Save(PlanCobro planCobro, string[] selectedRubrosCobro)
        {
            throw new NotImplementedException();
        }
    }
}
