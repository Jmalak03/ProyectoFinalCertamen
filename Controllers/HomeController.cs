using AppCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using AppCrud.Repositorios.Contrato;
using APPCRUD.Models;

namespace AppCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Formacion> _formacionRepository;
        private readonly IGenericRepository<Participante> _participanteRepository;

        public HomeController(ILogger<HomeController> logger, 
            IGenericRepository<Formacion> departamentoRepository,
            IGenericRepository<Participante> empleadoRepository)
        {
            _logger = logger;
            _formacionRepository = departamentoRepository;
            _participanteRepository = empleadoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Requisitos()
        {
            return View();
        }

        public IActionResult Votos()
        {
            return View();
        }



        [HttpGet]
        public async Task< IActionResult> listaFormacion()
        {
            List<Formacion> _lista = await _formacionRepository.Lista();

            return StatusCode(StatusCodes.Status200OK, _lista);
        }

        [HttpGet]
        public async Task<IActionResult> listaParticipantes()
        {
            List<Participante> _lista = await _participanteRepository.Lista();

            return StatusCode(StatusCodes.Status200OK, _lista);
        }

        [HttpPost]
        public async Task<IActionResult> guardarParticipante([FromBody] Participante modelo)
        {
            bool _resultado = await _participanteRepository.Guardar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

        [HttpPut]
        public async Task<IActionResult> editarParticipante([FromBody] Participante modelo)
        {
            bool _resultado = await _participanteRepository.Editar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }

        [HttpDelete]
        public async Task<IActionResult> eliminarParticipante(int idParticipante)
        {
            bool _resultado = await _participanteRepository.Eliminar(idParticipante);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "errror" });
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}