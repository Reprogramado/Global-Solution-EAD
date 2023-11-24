using GS.DataBase;
using GS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace GS.Controllers
{
    public class MedicoController : Controller
    {
        private BancoContext _context;

        public MedicoController(BancoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            TempData["msg"] = "Médico registrado";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Index()
        {
            var medicos = _context.Medicos.ToList();
            return View(medicos);
        }
    }
}
