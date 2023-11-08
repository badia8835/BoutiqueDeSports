using System.ComponentModel.DataAnnotations;

namespace Catalogue.Models
{
    public class Hockey
    {
        public int Id { get; set; } // Identifiant unique

        [Required(ErrorMessage = "Le champ Nom du produit est requis.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Le nom du produit doit avoir entre 3 et 100 caractères.")]
        public string NomProduit { get; set; } // Nom du produit

        [Required(ErrorMessage = "Le champ Marque est requis.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La marque doit avoir entre 2 et 50 caractères.")]
        public string Marque { get; set; } // Marque

        public string Taille { get; set; } // Taille (optionnel selon le type d'article)

        [Range(0, int.MaxValue, ErrorMessage = "La quantité en inventaire doit être un nombre positif.")]
        public int QuantiteEnInventaire { get; set; } // Quantité en inventaire

        public string Photo { get; set; } // URL de la photo (ou chemin local)

        public string Categorie { get; set; } // Catégorie

        public string DescriptionDetaillee { get; set; } // Description détaillée

    }
}
