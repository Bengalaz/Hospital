using System.Collections.Generic;
using System.Linq;
using Hospital.Entity;
using Hospital.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.implementation
{
    public class ConsultaRepository : IConsultaRepository
    {

        private ApplicationDbContext context;

        public ConsultaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
             try
            {
                var result = new Consulta();
                result = context.consultas.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public Consulta Get(int id)
        {
            var result = new Consulta();
            try
            {
                result = context.consultas.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Consulta> GetAll()
        {
            var result = new List<Consulta>();
            try
            {
                result = context.consultas.Include(c =>c.PacienteId).ToList();
                result.Select(c => new Consulta{
                
                    Id=c.Id,
                    PacienteId = c.PacienteId,
                    Descripcion = c.Descripcion
                
                });
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Consulta entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Consulta entity)
        {
            try{
               var ConsultaOrigin = context.consultas.Single(
                   a => a.Id == entity.Id
               );
            ConsultaOrigin.Id = entity.Id;
            ConsultaOrigin.Descripcion=entity.Descripcion;
            ConsultaOrigin.PacienteId=entity.PacienteId;

            context.Update(ConsultaOrigin);
            context.SaveChanges();
           }
           catch
           {
             throw;
           }
           return true;
        }
    }
}