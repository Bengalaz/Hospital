using System.Collections.Generic;
using System.Linq;
using Hospital.Entity;
using Hospital.Repository.Context;

namespace Hospital.Repository.implementation
{
    public class PacienteRepository : IPacienteRepository
    {
        private ApplicationDbContext context;

        public PacienteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

         public Paciente Get(int id)
        {
            var result = new Paciente();
            try{
                result = context.pacientes.Single(x => x.Id == id);
            }
            catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = new Paciente();
                result = context.pacientes.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public IEnumerable<Paciente> GetAll()
        {
            var result = new List<Paciente>();
            try
            {
                result = context.pacientes.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Paciente entity)
        {
             try{
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Paciente entity)
        {
            try{
                var pacienteOrigin = context.pacientes.Single(
                    x=> x.Id == entity.Id
                );

                pacienteOrigin.Id = entity.Id;
                pacienteOrigin.Nombre = entity.Nombre;
                pacienteOrigin.Apellido = entity.Apellido;
                pacienteOrigin.Dni = entity.Dni;
                pacienteOrigin.Direccion = entity.Direccion;
                pacienteOrigin.Telefono = entity.Telefono;
                context.Update(pacienteOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}