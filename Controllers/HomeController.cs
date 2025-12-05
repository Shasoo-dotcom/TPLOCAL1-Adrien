using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":

                        var listeAvis = new OpinionList().GetAvis("XlmFile/DataAvis.xml");
                        return View("OpinionList", listeAvis);
                    case "Form":
                        return View("Form", new FormModel());
                    default:
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!string.IsNullOrWhiteSpace(model.Prenom) && Regex.IsMatch(model.Prenom, @"[^a-zA-Z\-]"))
                ModelState.AddModelError(nameof(model.Prenom), "Entrez un prénom valide.");
            if (!string.IsNullOrWhiteSpace(model.Nom) && Regex.IsMatch(model.Nom, @"[^a-zA-Z\-]"))
                ModelState.AddModelError(nameof(model.Nom), "Entrez un nom valide.");
            if (model.DateDebut.HasValue && model.DateDebut.Value >= new DateTime(2021, 1, 1))
                ModelState.AddModelError(nameof(model.DateDebut), "La date doit être antérieure au 01/01/2021");
            if (!string.IsNullOrWhiteSpace(model.CodePostal) && (model.CodePostal.Length != 5 || !Regex.IsMatch(model.CodePostal, @"^\d+$")))
                ModelState.AddModelError(nameof(model.CodePostal), "Un code postal doit contenir 5 chiffres.");
            if (!string.IsNullOrWhiteSpace(model.TypeFormation) && !Regex.IsMatch(model.Email, pattern))
                ModelState.AddModelError(nameof(model.Email), "Format e-mail invalide.");
            if (!ModelState.IsValid)
                return View("Form", model);
            return View("Validation", model);
        }
    }
}