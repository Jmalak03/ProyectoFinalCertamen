using FreeSql;
using Microsoft.AspNetCore.Mvc;

namespace APPCRUD.Controllers
{
    public class VotacionController : Controller
    {
        private DbContext _context;

        public VotacionController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Votar(int Id)
        {
            var concursante = _context.Concursante.FirstOrDefault(c => c.Id == Id);
            if (concursante != null)
            {
                concursante.Votos++;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
