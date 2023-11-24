using GS.DataBase;
using GS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace GS.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly BancoContext _context;

        public BeneficiarioController(BancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Beneficiario beneficiario)
        {
            _context.Beneficiarios.Add(beneficiario);
            _context.SaveChanges();
            TempData["msg"] = "Beneficiario registrado";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var beneficiarios = _context.Beneficiarios.ToList();
            return View(beneficiarios);
        }
    }
}
