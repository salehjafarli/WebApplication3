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
using WebApplication3.Mappers;
using WebApplication3.Models;
using WebApplication3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    public class ChiefController : BaseController
    {

        public ChiefController(UserManager<User> userManager) : base(userManager)
        {
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            using (CateringContext context = new CateringContext())
            {
                var x = context.Chiefs.Include(z => z.Creator).Where(xa => xa.IsDeleted == false).ToList();

                List<ChiefModel> chiefs1 = x.Select(z => Mapper<Chief, ChiefModel>.Map(z)).ToList();
                ChiefViewModel chiefViewModel = new ChiefViewModel();
                chiefViewModel.CurrentUser = CurrentUser;
                chiefViewModel.Models = chiefs1;

                return View(chiefViewModel);
            }
            
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (CateringContext context = new CateringContext())
            {
                var x = context.Chiefs.FirstOrDefault(x => x.Id == id);
                ChiefModel chiefModel = new ChiefModel();
                if (x != null)
                {
                    chiefModel = Mapper<Chief, ChiefModel>.Map(x);
                    chiefModel.ButtonText = "Update";
                }
                return View(chiefModel);
            }          
        }


        [HttpPost]
        public IActionResult Save(ChiefModel chiefModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            using (CateringContext context = new CateringContext())
            {


                Chief chief = Mappers.Mapper<Chief, ChiefModel>.Map(chiefModel);
                chief.CreatorId = CurrentUser.Id;
                chief.LastModifiedDate = DateTime.UtcNow;
                chief.IsDeleted = false;
                if (chiefModel.Id != 0)
                {
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
                chief.CreatorId = CurrentUser.Id;
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
    }
}
