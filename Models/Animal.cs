using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Assurez-vous d'importer cet espace de noms pour IFormFile

namespace dotNet.Models
{
    public class Animal
    {
        public int key { get; set; }

        [Required(ErrorMessage = "Le nombre de pattes est requis")]
        [Range(0, 8, ErrorMessage = "Le nombre de pattes doit être entre 0 et 8")]
        public int pattes { get; set; }

        [Required(ErrorMessage = "Le type est requis")]
        public string? type { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string? nom { get; set; }

        [Required(ErrorMessage = "La couleur est requise")]
        public string? couleur { get; set; }

        public string? ImageF { get; set; } // Chemin de l'image

        // Constructeur par défaut
        public Animal() { }

        // Constructeur avec paramètres
        public Animal(int k, int p, string t, string n, string c, string i)
        {
            this.key = k;
            this.pattes = p;
            this.type = t;
            this.nom = n;
            this.couleur = c;
            this.ImageF = i;
        }
    }
}
