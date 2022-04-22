using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetVet.Models;

namespace PetVet.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult cadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastroUsuario(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Create(u);
            ViewBag.Mensagem = "Usuário cadastrado com sucesso!";
            return View();
        }

        public IActionResult listarUsuario()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login");
            }

            UsuarioRepository ur = new UsuarioRepository();
            List<Usuario> usuarios = ur.Listar();
            return View(usuarios);
        }

        public IActionResult editar(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login");
            }

            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.UserId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult editar(Usuario u)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login");
            }

            UsuarioRepository ur = new UsuarioRepository();
            ur.Atualizar(u);
            return RedirectToAction("listarUsuario");
        }
        public IActionResult Remover(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            UsuarioRepository ur = new UsuarioRepository();
            ur.Remover(id);
            return RedirectToAction("listarUsuario");
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.QueryLogin(u);
            if (usuario != null)
            {
                ViewBag.Mensagem = "Você está logado!";
                HttpContext.Session.SetInt32("userId", usuario.Id);
                HttpContext.Session.SetString("username", usuario.Nome);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}