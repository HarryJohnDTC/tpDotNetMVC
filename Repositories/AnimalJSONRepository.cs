using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using dotNet.Models;

namespace dotNet.Repositories
{
    public class AnimalJSONRepository
    {
        private readonly string _filepath = "App_data/liste_animal.json"; // Chemin vers le fichier JSON

        // Charge tous les animaux depuis le fichier JSON
        public List<Animal> GetAllAnimals()
        {
            if (!File.Exists(_filepath))
            {
                return new List<Animal>(); // Retourne une liste vide si le fichier n'existe pas
            }

            var jsonData = File.ReadAllText(_filepath);
            return JsonConvert.DeserializeObject<List<Animal>>(jsonData) ?? new List<Animal>(); // Désérialise le JSON en List<Animal>
        }

        // Sauvegarde la liste des animaux dans le fichier JSON
        public void SaveAnimals(List<Animal> animals)
        {
            var jsonData = JsonConvert.SerializeObject(animals, Formatting.Indented); // Sérialise les animaux en JSON
            File.WriteAllText(_filepath, jsonData);
        }

        // Ajoute un nouvel animal
public void AddAnimal(Animal animal)
{
    var animals = GetAllAnimals();

    // Génère un identifiant unique en utilisant la taille actuelle de la liste + 1
    if (animals.Count == 0)
    {
        animal.key = 1; // Si la liste est vide, on commence à 1
    }
    else
    {
        animal.key = animals.Max(a => a.key) + 1; // Sinon, on incrémente la clé
    }
    
    animals.Add(animal);
    SaveAnimals(animals);
}


        // Supprime un animal par son nom (ou par un autre identifiant)
        // Supprime un animal par sa clé (key)
public void DeleteAnimal(int key)
{
    var animals = GetAllAnimals();
    var animalToRemove = animals.FirstOrDefault(a => a.key == key); // Utilise la clé pour trouver l'animal
    if (animalToRemove != null)
    {
        animals.Remove(animalToRemove);
        SaveAnimals(animals);
    }
}

    }
}
