using System.Collections.Generic;
using Hospital.Entity;
using Hospital.Repository;

namespace Hospital.Service.implementation
{
    public class ConsultaService : IConsultaService
    {
        private IConsultaRepository consultaRepository;
        public ConsultaService(IConsultaRepository consultaRepository)
        {
            this.consultaRepository = consultaRepository;
        }
        public bool Delete(int id)
        {
           return  consultaRepository.Delete(id);
        }

        public Consulta Get(int id)
        {
            return consultaRepository.Get(id);
        }

        public IEnumerable<Consulta> GetAll()
        {
            return consultaRepository.GetAll();
        }

        public bool Save(Consulta entity)
        {
            return consultaRepository.Save(entity);
        }

        public bool Update(Consulta entity)
        {
            return consultaRepository.Update(entity);
        }
    }
}