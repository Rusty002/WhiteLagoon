using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VillaNumberController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var villaNumbers = _applicationDbContext.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new ()
            {
                VillaList = _applicationDbContext.Villas.ToList().Select(
                    u => new SelectListItem
                    {
                        Text = u.VillaName,
                        Value = u.VillaId.ToString()
                    })
            };

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            //ModelState.Remove("Villa");
            bool villaNumberExists = _applicationDbContext.VillaNumbers.Any(v => v.Villa_Number == obj.VillaNumber.Villa_Number);
            
            if (ModelState.IsValid && !villaNumberExists)
            {
                _applicationDbContext.VillaNumbers.Add(obj.VillaNumber);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Villa Number could not be created.";

            obj.VillaList = _applicationDbContext.Villas.ToList().Select(
                                                        u => new SelectListItem
                                                        {
                                                            Text = u.VillaName,
                                                            Value = u.VillaId.ToString()
                                                        });
            return View(obj);
        }

        public IActionResult Update(int villaNumberId)
        {
            //Villa? villa1 = _applicationDbContext.Villas.Find(villaId);
            //List<Villa> villaList = _applicationDbContext.Villas.Where(v => v.VillaPrice >= 50).ToList();
            //Villa? villa = _applicationDbContext.Villas.FirstOrDefault(v => v.VillaId == villaId);

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _applicationDbContext.Villas.ToList().Select(
                u => new SelectListItem
                {
                    Text = u.VillaName,
                    Value = u.VillaId.ToString()
                }),
                VillaNumber = _applicationDbContext.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };
            if (villaNumberVM.VillaNumber == null)
                return RedirectToAction("Error", "Home");

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {

            if (ModelState.IsValid)
            {
                _applicationDbContext.VillaNumbers.Update(villaNumberVM.VillaNumber);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Villa Number could not be updated.";

            villaNumberVM.VillaList = _applicationDbContext.Villas.ToList().Select(
                                                        u => new SelectListItem
                                                        {
                                                            Text = u.VillaName,
                                                            Value = u.VillaId.ToString()
                                                        });
            return View(villaNumberVM);
        }

        public IActionResult Delete(int villaNumberId)
        {

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _applicationDbContext.Villas.ToList().Select(
                u => new SelectListItem
                {
                    Text = u.VillaName,
                    Value = u.VillaId.ToString()
                }),
                VillaNumber = _applicationDbContext.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };
            if (villaNumberVM.VillaNumber == null)
                return RedirectToAction("Error", "Home");

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? villaEntity = _applicationDbContext.VillaNumbers.FirstOrDefault(v => v.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

            if (villaEntity is not null)
            {
                _applicationDbContext.VillaNumbers.Remove(villaEntity);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Villa number could not be deleted.";
            return View(villaNumberVM);
        }

    }
}
