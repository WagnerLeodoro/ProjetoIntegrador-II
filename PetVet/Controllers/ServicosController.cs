using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetVet.Models;

namespace PetVet.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult agendarServicos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult agendarServicos(Agenda a)
        {

            AgendaRepository ar = new AgendaRepository();
            ar.CreateAgenda(a);
            ViewBag.Mensagem = "Evento cadastrado com sucesso!";
            return View();
        }
        public IActionResult agenda()
        {
            return View();
        }

        public IActionResult listaAgenda()
        {
            AgendaRepository ar = new AgendaRepository();
            List<Agenda> listaAgenda = ar.Listar();
            return View(listaAgenda);
        }
        public IActionResult editarAgenda(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login", "Usuario");
            }

            AgendaRepository ar = new AgendaRepository();
            Agenda agenda = ar.GetAgendaId(id);
            return View(agenda);
        }
        [HttpPost]
        public IActionResult editarAgenda(Agenda a)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login", "Usuario");
            }

            AgendaRepository ar = new AgendaRepository();
            ar.Atualizar(a);
            return RedirectToAction("listaAgenda");
        }
        public IActionResult Remover(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login", "Usuario");
            }

            AgendaRepository ar = new AgendaRepository();
            ar.Remover(id);
            return RedirectToAction("listaAgenda");
        }

        public IActionResult catalogoProdutos()
        {
            return View();
        }
    }
}