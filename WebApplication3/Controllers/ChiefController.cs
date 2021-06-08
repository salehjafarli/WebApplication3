using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.EntityModels;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class ChiefController : BaseController
    {

        public ChiefController(UserManager<User> userManager) : base(userManager)
        {
            
        }

        public IActionResult Index()
        {
            using (CateringContext context = new CateringContext())
            {
                var x = context.Chiefs.Where(xa => xa.IsDeleted == false).ToList();

                List<ChiefModel> chiefs1 = x.Select(z => Mappers.Mapper<Chief, ChiefModel>.Map(z)).ToList();
                ChiefViewModel chiefViewModel = new ChiefViewModel();
                chiefViewModel.CurrentUser = CurrentUser;
                chiefViewModel.Models = chiefs1;

                //  ViewBag.Chiefs = context.Chiefs.Where(xa  => xa.IsDeleted == false).ToList();

                return View(chiefViewModel);
            }
            
            
        }

        public IActionResult Update(int id)
        {
            using (CateringContext context = new CateringContext())
            {
                var x = context.Chiefs.FirstOrDefault(x => x.Id == id);


                ChiefModel chiefModel = new ChiefModel();
                if (x != null)
                {
                    chiefModel.Id = x.Id;
                    chiefModel.Name = x.Name;
                    chiefModel.Note = x.Note;
                    chiefModel.Phone = x.Phone;
                    chiefModel.Email = x.Email;
                }
                return View(chiefModel);
            }
           
            
            
        }


        [HttpPost]
        [Route("Save")]
       //  [ValidateAntiForgeryToken]
        public IActionResult Save(ChiefModel chiefModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            using (CateringContext context = new CateringContext())
            {
                if (chiefModel.Id != 0)
                {
                    Chief chief = Mappers.Mapper<Chief, ChiefModel>.Map(chiefModel);
                    chief.LastModifiedDate = DateTime.UtcNow;
                    //chief.Creator = CurrentUser;
                    context.Update(chief);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }
                else
                {
                    Chief chief = Mappers.Mapper<Chief, ChiefModel>.Map(chiefModel);
                    //chief.Creator = CurrentUser;
                    chief.LastModifiedDate = DateTime.UtcNow;
                    chief.IsDeleted = false;
                    context.Add(chief);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            using (CateringContext context = new CateringContext())
            {
                Chief chief = context.Chiefs.FirstOrDefault(x => x.Id == id);
                chief.LastModifiedDate = DateTime.UtcNow;
                //chief.Creator = CurrentUser;
                chief.IsDeleted = true;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction("Index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
