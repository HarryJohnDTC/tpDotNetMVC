using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


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

    public string? ImageF { get; set; }

public Animal() {}

    public Animal(int k, int p, string t, string n, string c, string i){
        this.key = k;
        this.pattes = p;
        this.type = t;
        this.nom = n;
        this.couleur = c;
        this.ImageF = i;
    }
}
}