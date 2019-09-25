using Ecommerce.Infra.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext db;

        private static Contador _CONTADOR = new Contador();

        public HomeController(DatabaseContext db) => this.db = db;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public object Get()
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();

                return new
                {
                    _CONTADOR.ValorAtual,
                    Environment.MachineName,
                    Sistema = Environment.OSVersion.VersionString
                };
            }
        }
    }

    public class Contador
    {
        private int _valorAtual = 0;

        public int ValorAtual { get => _valorAtual; }

        public void Incrementar()
        {
            _valorAtual++;
        }
    }
}
