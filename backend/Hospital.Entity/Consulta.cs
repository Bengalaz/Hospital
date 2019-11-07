namespace Hospital.Entity
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int PacienteId { get; set; }
        public Paciente paciente{ get; set; }
    }
}