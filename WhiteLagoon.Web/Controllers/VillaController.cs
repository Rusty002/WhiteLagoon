using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VillaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var villas = _applicationDbContext.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa) 
        {
            if (villa.VillaName.ToLower() == villa.VillaDescription.ToLower())
                ModelState.AddModelError("villaname", "The Description cannot be same as name");

            if (ModelState.IsValid)
            {
                _applicationDbContext.Villas.Add(villa);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been created successfully.";
                return RedirectToAction("Index", "Villa");                
            }

            TempData["error"] = "The Villa could not be created.";
            return View(villa);
        }

        public IActionResult Update(Guid villaId)
        {
            //Villa? villa1 = _applicationDbContext.Villas.Find(villaId);
            //List<Villa> villaList = _applicationDbContext.Villas.Where(v => v.VillaPrice >= 50).ToList();
            Villa? villa = _applicationDbContext.Villas.FirstOrDefault(v => v.VillaId == villaId);
            
            if (villa == null)
                return RedirectToAction("Error", "Home");

            return View(villa);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {

            if (ModelState.IsValid)
            {
                _applicationDbContext.Villas.Update(villa);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been updated successfully.";
                return RedirectToAction("Index", "Villa");
            }

            TempData["error"] = "The Villa could not be updated.";
            return View(villa);
        }
        
        public IActionResult Delete(Guid villaId)
        {
            Villa? villa = _applicationDbContext.Villas.FirstOrDefault(v => v.VillaId == villaId);
            
            if (villa is null)
                return RedirectToAction("Error", "Home");

            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? villaEntity = _applicationDbContext.Villas.FirstOrDefault(v => v.VillaId == villa.VillaId);

            if (villaEntity is not null)
            {
                _applicationDbContext.Villas.Remove(villaEntity);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been deleted successfully.";
                return RedirectToAction("Index", "Villa");
            }

            TempData["error"] = "The Villa could not be deleted.";
            return View(villa);
        }
    }
}
