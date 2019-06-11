using Frota.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frota.WebAPP.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoApplication _veiculoApplication;

        public VeiculoController(IVeiculoApplication veiculoApplication)
        {
            _veiculoApplication = veiculoApplication;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var veiculos = _veiculoApplication.ObterTodos();

            return View(veiculos);
        }
    }
}
