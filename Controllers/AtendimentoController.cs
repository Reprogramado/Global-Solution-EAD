using GS.DataBase;
using GS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace GS.Controllers
{
    public class AtendimentoController : Controller
    {
        private BancoContext _context;

       
        public AtendimentoController(BancoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(AtendimentoBeneficiario medicoBeneficiario)
        {
            
            _context.AtendimentosBeneficiarios.Add(medicoBeneficiario);
            
            _context.SaveChanges();
            //Mensagem
            TempData["msg"] = "Beneficiario adicionado";
            //Redirect
            return RedirectToAction("Add", new { id = medicoBeneficiario.AtendimentoId });
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            
            var beneficiariosAtendimentos = _context.AtendimentosBeneficiarios
                .Where(f => f.AtendimentoId == id)
                .Select(f => f.Beneficiario)
                .ToList();

            var todosBeneficiarios = _context.Beneficiarios.ToList();

            //Tira uma lista da outra
            var lista = todosBeneficiarios.Where(f => !beneficiariosAtendimentos.Contains(f));

            ViewBag.beneficiarios = lista;
           
            var atendimento = _context.Atendimentos.Find(id);
            ViewBag.atendimento = atendimento;
            return View();
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
           
            var beneficiarios = _context.AtendimentosBeneficiarios
                .Where(f => f.AtendimentoId == id)
                .Select(f => f.Beneficiario)
                .ToList();
           
            ViewBag.beneficiarios = beneficiarios;
            
            var atendimento = _context.Atendimentos.Include(f => f.Medico).First(f => f.AtendimentoId == id);
           
            return View(atendimento);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            
            var atendimento = _context.Atendimentos.Find(id);
            
            _context.Atendimentos.Remove(atendimento);
            _context.SaveChanges();
            
            TempData["msg"] = "Atendimento removido!";
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarMedicos();
            
            var atendimento = _context.Atendimentos.Find(id);
          
            return View(atendimento);
        }

        [HttpPost]
        public IActionResult Editar(Atendimento atendimento)
        {
            
            _context.Atendimentos.Update(atendimento);
            _context.SaveChanges();
            
            TempData["msg"] = "Atendimento atualizado!";
            
            return RedirectToAction("Index");
        }

        public IActionResult Index(string termoBusca)
        {
            
            var lista = _context.Atendimentos
                    .Where(f => f.Dor.Contains(termoBusca) || termoBusca == null)
                    .Include(f => f.Medico)
                    .ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarMedicos();
            return View();
        }

        
        private void CarregarMedicos()
        {
            
            var lista = _context.Medicos.ToList();
            
            ViewBag.medicos = new SelectList(lista, "MedicoId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();
            TempData["msg"] = "Atendimento registrado!";
            return RedirectToAction("Cadastrar");
        }

    }
}
