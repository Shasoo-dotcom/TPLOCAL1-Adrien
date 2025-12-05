using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Le champ Nom est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Sexe est obligatoire")]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est obligatoire")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le champ Code Postal est obligatoire")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Le champ Ville est obligatoire")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Le champ Email est obligatoire")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Date de début est obligatoire")]
        public DateTime? DateDebut { get; set; }

        [Required(ErrorMessage = "Le champ Formation est obligatoire")]
        public string TypeFormation { get; set; }
        [Required(ErrorMessage = "Champ obligatoire, entrer N si non effectuée")]
        public string AvisCobol { get; set; }
        [Required(ErrorMessage = "Champ obligatoire, entrer N si non effectuée")]
        public string AvisCSharp { get; set; }
    }
}
