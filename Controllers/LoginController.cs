using Microsoft.AspNetCore.Mvc;
using dotNet.Models;
using System.Linq;

namespace dotNet.Controllers
{
    public class LoginController : Controller
    {
        private UserJSONRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserJSONRepository();
        }

        // Afficher la page de connexion
        public ActionResult Index()
        {
            return View();
        }

// Action pour gérer la soumission du formulaire de connexion
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult List(Login model)
{
    if (ModelState.IsValid)
    {
        // Récupérer tous les utilisateurs pour validation
        var users = _userRepository.GetUsers();
        var user = users.FirstOrDefault(u => u.UserName == model.UserName);

        if (user != null && user.Password == model.Password) // Vérifiez le mot de passe haché ici
        {
            // Rediriger vers la page /Animal après connexion réussie
            return RedirectToAction("Index", "Animal"); // Assurez-vous que votre contrôleur Animal a une action Index
        }
        else
        {
            ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe invalide.");
        }
    }
    return View("Index", model);
}


        // Action pour afficher la page d'inscription
        public ActionResult Register()
        {
            return View();
        }

        // Action pour gérer la soumission du formulaire d'inscription
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Login model)
        {
            if (ModelState.IsValid)
            {
                // Vérifier si l'utilisateur existe déjà
                var existingUsers = _userRepository.GetUsers();
                if (existingUsers.Any(u => u.UserName == model.UserName))
                {
                    ModelState.AddModelError("", "Ce nom d'utilisateur est déjà pris.");
                }
                else
                {
                    // Créer un nouvel utilisateur et le sauvegarder
                    var newUser = new Login
                    {
                        UserId = existingUsers.Count + 1, // Vous pouvez utiliser un ID unique réel ici
                        UserName = model.UserName,
                        Password = model.Password // Pensez à hacher le mot de passe ici
                    };
                    _userRepository.SaveUser(newUser);

                    // Rediriger vers la page de connexion après l'inscription réussie
                    return RedirectToAction("Index");
                }
            }

            // Si quelque chose a échoué, afficher à nouveau le formulaire
            return View(model);
        }
    }
}
