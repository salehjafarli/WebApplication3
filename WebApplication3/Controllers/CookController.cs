using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.EntityModels;
using WebApplication3.ViewModels;
using WebApplication3.Mappers;
using WebApplication3.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    public class CookController : BaseController
    {
        public CookController(UserManager<User> userManager) : base(userManager)
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            CookViewModel vm = new CookViewModel();
            vm.CurrentUser = CurrentUser;
            using (CateringContext c = new CateringContext())
            {
                var cookdata = c.Cooks.Include(x => x.Creator).Include(x => x.CookCategory).ToList();
                vm.Cooks = cookdata.Where(x => x.IsDeleted == false)
                                    .Select((x) => {

                                        var cookmodel = Mapper<Cook, CookModel>.Map(x);
                                        cookmodel.CookCategory = Mapper<CookCategory, CategoryModel>.Map(x.CookCategory);
                                        return cookmodel;

                                    }).ToList();

            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CookModel cook;
            List<SelectListItem> sl;
            using (CateringContext c = new CateringContext())
            {
                var cook1 = c.Cooks.Include(z => z.Creator).Include(z => z.CookCategory).FirstOrDefault(z => z.Id == id);
                if (cook1 != null)
                {
                    cook = Mapper<Cook, CookModel>.Map(cook1);
                    cook.ButtonText = "Update";
                    cook.CookCategory = Mapper<CookCategory, CategoryModel>.Map(cook1.CookCategory);
                }
                else
                {
                    cook = new CookModel();
                }

                var x = c.CookCategories.Where(x => x.IsDeleted == false);
                sl = x.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            }
            cook.Categories = sl;
            if (id != 0)
            {
                cook.Categories.FirstOrDefault(x => x.Value == cook.CookCategory.Id.ToString()).Selected = true;
            }
            return View(cook);
        }


        [HttpPost]
        public IActionResult Save(CookModel cook)
        {
            if (!ModelState.IsValid)
            {
                return View(cook);
            }
            Cook cook1 = Mapper<Cook, CookModel>.Map(cook);
            cook1.CookCategoryId = cook.CookCategory.Id;
            cook1.IsDeleted = false;
            cook1.CreatorId = CurrentUser.Id;
            cook1.LastModifiedDate = DateTime.UtcNow;
            if (cook.Id == 0)
            {
                cook1.IsDeleted = false;
                using (CateringContext c = new CateringContext())
                {
                    try
                    {
                        c.Add(cook1);
                        c.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return Content("Error");
                    }
                }
            }
            else {
                using (CateringContext c = new CateringContext())
                {
                    try
                    {
                        c.Update(cook1);
                        c.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return Content("Error");
                    }
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (CateringContext c = new CateringContext())
            {
                Cook cook = c.Cooks.FirstOrDefault(x => x.Id == id) ?? new Cook();
                cook.IsDeleted = true;
                try
                {
                    c.SaveChanges();
                }
                catch (Exception)
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
