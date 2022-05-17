using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concecionaria.Datos;
using Concecionaria.Models;

namespace Concecionaria.Controllers
{
    public class MantenedorController : Controller
    {
        VehiculoDatos _vehiculoDatos = new VehiculoDatos();
        public IActionResult Listar()
        {
            var oLista = _vehiculoDatos.listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(VehiculoModel oVehiculo)
        {
            var respuesta = _vehiculoDatos.guardar(oVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
