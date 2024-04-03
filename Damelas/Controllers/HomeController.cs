using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Damelas.Models;
using System.Text.Json;

namespace Damelas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
      
      List<sushi> sushis = [];
      using (StreamReader leitor = new("Data\\sushis.json"))
      {
        string dados = leitor.ReadToEnd();
        sushis = JsonSerializer.Deserialize<List<sushi>>(dados);
      }
      List<Tipo> tipos = [];
      using (StreamReader leitor = new("Data\\sushis.json"));
        {

          string dados = leitor.ReadToEnd();
          sushis = JsonSerializer.Deserialize<List<Tipo>>(dados);

        }
        ViewData["Tipos"] = tipos;
        return View(sushis);
        
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
