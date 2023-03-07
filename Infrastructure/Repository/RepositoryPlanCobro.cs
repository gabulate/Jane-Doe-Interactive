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
            int retorno = 0;
            PlanCobro oPlanCobro = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;   
                oPlanCobro = GetPlanCobroByID((int)planCobro.Id);
                IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();

                if(oPlanCobro == null )
                {
                    if(selectedRubrosCobro!= null)
                    {
                        planCobro.RubroCobro = new List<RubroCobro>();
                        foreach (var rubro in selectedRubrosCobro)
                        {
                            var rubroToAdd = _RepositoryRubroCobro.GetRubroCobroByID(int.Parse(rubro));
                            ctx.RubroCobro.Attach(rubroToAdd);
                            ctx.RubroCobro.Add(rubroToAdd);
                        }
                    }
                    ctx.PlanCobro.Add(planCobro);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.PlanCobro.Add(planCobro);
                    ctx.Entry(planCobro).State= EntityState.Modified;
                    retorno= ctx.SaveChanges();

                    var selectedRubrosCobroID = new HashSet<string>(selectedRubrosCobro);
                    if(selectedRubrosCobro != null)
                    {
                        ctx.Entry(planCobro).Collection(p => p.RubroCobro).Load();
                        var newRubroForPlan = ctx.RubroCobro.
                            Where(x => selectedRubrosCobroID.Contains(x.Id.ToString())).ToList();
                        planCobro.RubroCobro = newRubroForPlan;

                        ctx.Entry(planCobro).State = EntityState.Modified;
                        retorno= ctx.SaveChanges();

                    }
                }
            }
            if(retorno >= 0)
                oPlanCobro = GetPlanCobroByID((int)planCobro.Id);
            return oPlanCobro;
        }
    }
}
