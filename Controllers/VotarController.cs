using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using static APPCRUD.Models.VotacionModel;

namespace APPCRUD.Controllers
{
    [Route("api/votaciones")]
    [ApiController]
    public class VotarController : ControllerBase
    {
        private List<Concursante> concursantes = new List<Concursante>
        {
            new Concursante {ConcursanteId = 1, Concursantes = "Concursante1", Votos = 0},
            new Concursante {ConcursanteId = 2, Concursantes = "Concursante2", Votos = 0}
        };

        private List<Voto> votos = new List<Voto>();
        [HttpGet("Concursantes")]
        public ActionResult ConcursanteV()
        {
            return Ok(concursantes);
        }
        [HttpPost("Concursante")]
        public ActionResult Votar (Voto voto)
        {
            var concursante = concursantes.FirstOrDefault(c => c.ConcursanteId == voto.ConcursanteId);

            if (concursante == null)
            {
                return BadRequest("El concursante no existe.");
            }
            if(votos.Any(v => v.ConcursanteId == voto.ConcursanteId && v.UserId == voto.UserId))
            {
                return BadRequest("Ya has votado por este concursante.");
            }

            concursante.Votos++;
            
            votos.Add(voto);

            return Ok("Voto registrado exitosamante.");
        }
    }
}
