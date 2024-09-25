using Microsoft.AspNetCore.Mvc;
using dotNet.Models;
using dotNet.Repositories;
using System.Linq;

namespace dotNet.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalJSONRepository _repository;

        // Injection du dépôt dans le contrôleur
        public AnimalController()
        {
            _repository = new AnimalJSONRepository(); // Initialise le dépôt
        }

        // Action pour afficher la liste des animaux
        public IActionResult Index(int pageNumber = 1)
{
    int pageSize = 5; // Define the number of animals per page
    var animaux = _repository.GetAllAnimals(); // Get the full list of animals

    // Calculate the total number of pages
    int totalAnimals = animaux.Count;
    int totalPages = (int)Math.Ceiling(totalAnimals / (double)pageSize);

    // Get the animals for the current page
    var animauxForPage = animaux.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

    // Pass pagination data to the view
    ViewBag.TotalPages = totalPages;
    ViewBag.CurrentPage = pageNumber;

    return View(animauxForPage); // Pass only the animals for the current page to the view
}


        // Action pour afficher la page de création d'un nouvel animal
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Retourne la vue pour créer un nouvel animal
        }

        // Action pour traiter la soumission du formulaire de création
        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid) // Vérifie que le modèle est valide
            {
                _repository.AddAnimal(animal); // Ajoute l'animal via le dépôt
                return RedirectToAction("Index"); // Redirige vers la liste des animaux
            }
            return View(animal); // Retourne la vue avec le modèle en cas d'erreur
        }

        // Action pour afficher la page de suppression d'un animal
        [HttpGet]
        public IActionResult Delete(int key) // Changer le type de paramètre à `int`
        {
            var animal = _repository.GetAllAnimals().FirstOrDefault(a => a.key == key); // Utilise la clé pour trouver l'animal
            if (animal == null)
            {
                return NotFound(); // Retourne une erreur si l'animal n'est pas trouvé
            }
            return View(animal); // Retourne la vue avec l'animal à supprimer
        }

        // Action pour confirmer la suppression
[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int key)
{
    _repository.DeleteAnimal(key); // Supprime l'animal via le dépôt
    return RedirectToAction("Index"); // Redirige vers la liste des animaux
}


        // Action pour afficher le formulaire de modification
        [HttpGet]
        public IActionResult Edit(int key) // Changer le type de paramètre à `int`
        {
            var animal = _repository.GetAllAnimals().FirstOrDefault(a => a.key == key); // Utilise la clé pour trouver l'animal
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal); // Passe l'animal à la vue pour être modifié
        }

        // Action pour traiter la soumission du formulaire de modification
        [HttpPost]
public IActionResult Edit(Animal modifiedAnimal)
{
    try
    {
        if (ModelState.IsValid)
        {
            var animals = _repository.GetAllAnimals();
            // Recherche de l'animal à modifier par la clé (key)
            var animal = animals.FirstOrDefault(a => a.key == modifiedAnimal.key);

            if (animal != null)
            {
                // Mettre à jour toutes les propriétés, y compris le nom et l'image
                animal.nom = modifiedAnimal.nom;
                animal.type = modifiedAnimal.type;
                animal.couleur = modifiedAnimal.couleur;
                animal.pattes = modifiedAnimal.pattes;
                animal.ImageF = modifiedAnimal.ImageF; // Update Image URL

                // Sauvegarde des modifications dans le fichier JSON
                _repository.SaveAnimals(animals);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // Si le modèle n'est pas valide, retourne la vue avec les erreurs
        return View(modifiedAnimal);
    }
    catch (Exception ex)
    {
        // Gérer l'exception
        ModelState.AddModelError("", "Erreur lors de la modification de l'animal : " + ex.Message);
        return View(modifiedAnimal);
    }
}


    }
}
