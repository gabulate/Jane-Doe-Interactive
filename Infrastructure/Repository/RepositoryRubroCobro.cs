using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryRubroCobro : IRepositoryRubroCobro
    {
        public IEnumerable<RubroCobro> GetRubroCobro()
        {
            try
            {
                IEnumerable<RubroCobro> lista = null;
                using(MyContext ctx=new MyContext()) 
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista=ctx.RubroCobro.ToList<RubroCobro>();
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

        public RubroCobro GetRubroCobroByID(int id)
        {
            RubroCobro rubro = null;
            try
            {
                using(MyContext ctx= new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled=false;
                    rubro = ctx.RubroCobro.Find();
                }
                return rubro;
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


        public RubroCobro Save(RubroCobro rubro)
        {
            int retorno = 0;
            RubroCobro oRubro= null;
            using(MyContext ctx= new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled=false;
                oRubro = GetRubroCobroByID((int)rubro.Id);
                ctx.RubroCobro.Add(rubro);
                retorno = ctx.SaveChanges();
            }
            if(retorno >= 0)
            {
                oRubro = GetRubroCobroByID((int)rubro.Id);
            }
            return oRubro;
        }
    }
}
