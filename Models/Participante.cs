namespace AppCrud.Models
{
    public class Participante
    {
        public int idParticipante { get; set; }
        public string nombreCompleto { get; set; }
        public Formacion refFormacion { get; set; }
        public int pesoyaltura { get; set; }

		public int edad { get; set; }
		public string fechaContrato { get; set; }
    }
}
