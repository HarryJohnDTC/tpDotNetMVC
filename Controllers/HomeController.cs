using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Models;
using dotNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dotnet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Méthode GET pour afficher la vue initiale
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.data = new List<string> { "Coucou", "Bonjour" }; // Initialiser la liste ViewBag
            return View(new Visiteur()); // Passer un objet Visiteur vide à la vue
        }

        // Méthode POST avec une route différente pour éviter l'ambiguïté
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Visiteur v)
        {
            // Récupérer la valeur du champ de texte du formulaire
            string? prenom = Request.Form["prenom_visiteur"];

            // Créer un objet Visiteur et lui assigner la valeur du prénom
            Visiteur visiteur = new Visiteur();
            visiteur.prenom = prenom;

            ViewBag.data = new List<string> { "Coucou", "Bonjour" }; // Données dans ViewBag
            return View("Index", visiteur); // Renvoie la vue Index avec le modèle mis à jour
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
}
