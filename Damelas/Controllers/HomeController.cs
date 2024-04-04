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
      
      List<Produto> sushis = [];
      using (StreamReader leitor = new("Data\\produtos.json"))
      {
        string dados = leitor.ReadToEnd();
        sushis = JsonSerializer.Deserialize<List<Produto>>(dados);
      }

      List<Tipo> tipos = [];
      using (StreamReader leitor = new("Data\\tipos.json"))
        {

          string dados = leitor.ReadToEnd();
          tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);

        }
        ViewData["Tipos"] = tipos;
        return View(sushis);
        
    }

   public IActionResult Details(int id)
    {
      List<Produto> sushis = [];
      using (StreamReader leitor = new("Data\\produtos.json"))
      {
        string dados = leitor.ReadToEnd();
        sushis = JsonSerializer.Deserialize<List<Produto>>(dados);
      }

      List<Tipo> tipos = [];
      using (StreamReader leitor = new("Data\\tipos.json"))
        {

          string dados = leitor.ReadToEnd();
          tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
          }
        ViewData["Tipos"] = tipos;
        return View(sushis);
    }
          DetailsVM details = new(){
            Tipos = tipos,
            Atual = sushis.FirstOrDefault(p => p.Numero == id),
            Anterior = sushis.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = sushis.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero < id),
        };
        return View(details);
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
