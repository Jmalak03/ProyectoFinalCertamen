using FreeSql.Extensions;

namespace APPCRUD.Models
{
    public class VotacionModel
    {
        public class Concursante
        {
            public int ConcursanteId { get; set; }
            public string Concursantes { get; set; }
            public int Votos { get; set; }
         
        }

        public class Voto
        {
            public int VotoId { get; set; }
            public int  ConcursanteId { get; set; }
            public int UserId { get; set; }
        }
    }
}
