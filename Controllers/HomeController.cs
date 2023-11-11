using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalProg1.Models;
using ProyectoFinalProg1.Models.Entidades;

namespace ProyectoFinalProg1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        var estudiantes = new List<Noticias>(){
            new Noticias(){Titulo ="Balde", Resumen="FF"},
            new Noticias(){Titulo ="Joan", Resumen="Fernandez"}
        };

        ViewBag.lista=estudiantes;        
        ViewBag.titulo="Lista de estudiantes ViewBag";
        ViewBag.numero=38;
        return View();
    }

    public IActionResult Login()
    {        
        return View();
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
